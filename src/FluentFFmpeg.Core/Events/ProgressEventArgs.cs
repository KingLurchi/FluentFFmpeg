using System;
using System.Globalization;
using FluentFFmpeg.Core.Constants;
using FluentFFmpeg.Core.Extensions;
using FluentFFmpeg.Core.Models;

namespace FluentFFmpeg.Core.Events;

public class ProgressEventArgs : EventArgs
{
    internal ProgressEventArgs(string args)
    {
        var match = Patterns.Progress.Match(args);
        if (!match.Success)
            return;

        Bitrate = new Size<double>(match.ConvertFromGroup<double>("Bitrate"), match.ConvertFromGroup<string>("BitrateUnit"));
        Fps = match.ConvertFromGroup<double>("Fps");
        Frame = match.ConvertFromGroup<long>("Frame");
        Q = match.ConvertFromGroup<double>("Q");
        Size = new Size<int>(match.ConvertFromGroup<int>("Size"), match.ConvertFromGroup<string>("SizeUnit"));
        Speed = new Size<double>(match.ConvertFromGroup<double>("Speed"), "x");
        Time = TimeSpan.ParseExact(match.Groups["Time"].Value, "c", CultureInfo.InvariantCulture);
    }

    public Size<double> Bitrate { get; }
    public double Fps { get; }
    public long Frame { get; }
    public double Q { get; }
    public Size<int> Size { get; }
    public Size<double> Speed { get; }
    public TimeSpan Time { get; }

    public override string ToString() => $"frame={Frame} fps={Fps} q={Q} size={Size} time={Time} bitrate={Bitrate} speed={Speed}";
}