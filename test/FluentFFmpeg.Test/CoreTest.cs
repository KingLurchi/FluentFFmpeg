using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FluentFFmpeg.Core;
using FluentFFmpeg.Core.Constants;
using FluentFFmpeg.Core.Extensions;
using FluentFFmpeg.Core.Models;
using FluentFFmpeg.Core.Options;
using NUnit.Framework;

namespace FluentFFmpeg.Test;

public class CoreTest
{
    private const string Input = @"";  // use some non x265 video as input
    private const string Output = @""; // convert to x265

    private Instruction GetInstruction()
    {
        if(!File.Exists(Input))
            throw new FileNotFoundException("", Input);

        if (File.Exists(Output))
            File.Delete(Output);

        return new InstructionRoot(Options.Global.HideBanner)
            .AddInput(new Input(Input))
            .AddOutput(new Output(Output, new[]
            {
                Options.Output.Preset(Preset.Slower),
                Options.Output.Codec("v", "libx265"),
                Options.Output.Crf(28),
                Options.Output.Codec("a", "libvorbis"),
                Options.Output.Movflags()
            }))
            .GetInstruction();
    }

    [Test]
    public void ExecuteInstruction()
    {
        var instruction = GetInstruction();

        var ffmpeg = new FFmpeg();
        ffmpeg.Progress += e => { Debug.WriteLine(e); };
        ffmpeg.Execute(instruction);
    }

    [Test]
    public async Task ExecuteInstructionAsync()
    {
        var instruction = GetInstruction();

        var ffmpeg = new FFmpeg();
        ffmpeg.Progress += e => { Debug.WriteLine(e); };
        await ffmpeg.ExecuteAsync(instruction);
    }

    [Test]
    public async Task ConvertFromAacToMp3Async()
    {
        var ffmpeg = new FFmpeg();
        ffmpeg.Progress += e => { Debug.WriteLine(e); };

        var files = Directory.EnumerateFiles(@"D:\Downloads", "*.aac").Select(x => new FileInfo(x));
        foreach (var file in files)
        {
            var instruction = new InstructionRoot()
                .AddInput(new Input(file.FullName))
                .AddOutput(new Output(file.FullName.Replace(".aac", ".mp3")))
                .GetInstruction();

            await ffmpeg.ExecuteAsync(instruction);
        }
    }

    [Test]
    public async Task ConvertToX265()
    {
        var ffmpeg = new FFmpeg();
        ffmpeg.Progress += e => { Debug.WriteLine(e); };

        var files = Directory.EnumerateFiles(@"D:\Downloads", "*.mkv").Select(x => new FileInfo(x));
        foreach (var file in files)
        {
            var instruction = new InstructionRoot()
                .AddInput(new Input(file.FullName))
                .AddOutput(new Output(file.FullName.Replace(file.FullName, $"-{file.FullName}"), new []
                {
                    Options.Output.Codec("v", "hevc_vaapi"),
                    Options.Output.Movflags()
                }))
                .GetInstruction();

            await ffmpeg.ExecuteAsync(instruction);
        }
    }

    [Test]
    public async Task MergeAudioAndVideo()
    {
        var ffmpeg = new FFmpeg();
        ffmpeg.Progress += e => { Debug.WriteLine(e); };
            
        var files = Directory
            .EnumerateFiles(@"D:\Downloads")
            .Where(x => x.EndsWith("dashAudio") || x.EndsWith("dashVideo"))
            .Select(x => new FileInfo(x))
            .ToList();

        var splitFiles = files.Select(x => Path.GetFileNameWithoutExtension(x.Name)).Distinct().ToList();

        foreach (var splitFile in splitFiles)
        {
            var audio = files.FirstOrDefault(x => x.Name == $"{splitFile}.dashAudio");
            var video = files.FirstOrDefault(x => x.Name == $"{splitFile}.dashVideo");
                
            if (audio == null || video == null)
                continue;

            var instruction = new InstructionRoot()
                .AddInputs(new[] { new Input(audio.FullName), new Input(video.FullName) })
                .AddOutput(new Output($@"D:\Downloads\{splitFile}.mp4", new List<OutputOption>
                {
                    Options.Output.Codec("v","copy"),
                    Options.Output.Codec("a", "aac")
                }))
                .GetInstruction();

            await ffmpeg.ExecuteAsync(instruction);
            
            audio.Delete();
            video.Delete();
        }
    }
}