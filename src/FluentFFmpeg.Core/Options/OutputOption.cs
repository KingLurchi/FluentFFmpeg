namespace FluentFFmpeg.Core.Options
{
    public class OutputOption : BaseOption
    {
        public OutputOption(string flag) : base(flag)
        {
        }

        public OutputOption(string flag, string value) : base(flag, value)
        {
        }

        public OutputOption(string flag, string specifier, string value) : base(flag, specifier, value)
        {
        }
    }
}