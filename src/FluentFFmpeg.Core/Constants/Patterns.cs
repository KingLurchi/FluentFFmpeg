using System.Text.RegularExpressions;

namespace FluentFFmpeg.Core.Constants;

public static class Patterns
{
    public static readonly Regex Progress = new(@"frame=\s+(?<Frame>\d+)\sfps=\s*(?<Fps>\d*\.{0,1}\d+)\sq=(?<Q>\-{0,1}\d*\.{0,1}\d+)\ssize=(?<Size>\s*\d+)(?<SizeUnit>\w*)\stime=(?<Time>\d{2}\:\d{2}\:\d{2}\.\d{2})\sbitrate=\s*(?<Bitrate>\d+\.\d{1})(?<BitrateUnit>\w*\/\w*)\sspeed=\s*(?<Speed>\d*\.\d*)x");
}