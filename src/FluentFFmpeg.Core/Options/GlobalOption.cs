namespace FluentFFmpeg.Core.Options
{
    public class GlobalOption : BaseOption
    {
        public GlobalOption(string flag) : base(flag)
        {
        }

        public GlobalOption(string flag, string value) : base(flag, value)
        {
        }

        public GlobalOption(string flag, string specifier, string value) : base(flag, specifier, value)
        {
        }
    }
}