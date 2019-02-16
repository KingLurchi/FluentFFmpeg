namespace FluentFFmpeg.Core.Options
{
    public class SupportOption : BaseOption
    {
        public SupportOption(string flag) : base(flag)
        {
        }

        public SupportOption(string flag, string value) : base(flag, value)
        {
        }

        public SupportOption(string flag, string specifier, string value) : base(flag, specifier, value)
        {
        }
    }
}