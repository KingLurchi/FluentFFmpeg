namespace FluentFFmpeg.Core.Options
{
    public class BaseOption
    {
        private readonly string _specifier;
        private readonly string _value;

        protected BaseOption(string flag)
        {
            Flag = flag;
        }

        protected BaseOption(string flag, string value)
        {
            Flag = flag;

            _value = value;
        }

        protected BaseOption(string flag, string specifier, string value)
        {
            Flag = flag;

            _specifier = specifier;
            _value = value;
        }

        private string Flag { get; }

        private string Specifier => string.IsNullOrEmpty(_specifier) ? "" : $":{_specifier}";
        private string Value => string.IsNullOrEmpty(_value) ? "" : $" {_value}";

        public override string ToString()
        {
            return $"-{Flag}{Specifier}{Value}";
        }
    }
}