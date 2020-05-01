using System.Globalization;

namespace Iuliia.Utils
{
    internal static class StringExtensions
    {
        public static string Capitalize(this string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);
        }
    }
}