using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using FluentFFmpeg.Core;
using FluentFFmpeg.Core.Constants;
using FluentFFmpeg.Core.Extensions;
using FluentFFmpeg.Core.Models;
using NUnit.Framework;

namespace FluentFFmpeg.Test
{
    public class CoreTest
    {
        private const string Input = @"";  // use some non x265 video as input
        private const string Output = @""; // convert to x265

        private Instruction Setup()
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
            var instruction = Setup();

            var ffmpeg = new FFmpeg();
            ffmpeg.Progress += e => { Debug.WriteLine(e); };
            ffmpeg.Execute(instruction);
        }

        [Test]
        public async Task ExecuteInstructionAsync()
        {
            var instruction = Setup();

            var ffmpeg = new FFmpeg();
            ffmpeg.Progress += e => { Debug.WriteLine(e); };
            await ffmpeg.ExecuteAsync(instruction);
        }
    }
}