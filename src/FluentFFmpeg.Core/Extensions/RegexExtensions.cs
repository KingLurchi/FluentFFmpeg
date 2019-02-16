using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace FluentFFmpeg.Core.Extensions
{
    public static class RegexExtensions
    {
        public static T ConvertFromGroup<T>(this Match match, string group) where T : IConvertible
        {
            var value = match.Groups[group].Value;
            if (string.IsNullOrEmpty(value))
                return default;

            var type = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);
            try
            {
                return (T)Convert.ChangeType(value, type, CultureInfo.InvariantCulture);
            }
            catch
            {
                return default;
            }
        }
    }
}