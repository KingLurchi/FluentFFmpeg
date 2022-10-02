namespace FluentFFmpeg.Core.Options;

public class InputOption : BaseOption
{
    public InputOption(string flag) : base(flag)
    {
    }

    public InputOption(string flag, string value) : base(flag, value)
    {
    }

    public InputOption(string flag, string specifier, string value) : base(flag, specifier, value)
    {
    }
}