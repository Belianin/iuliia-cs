using System.Globalization;

namespace Iuliia
{
    internal static class StringExtensions
    {
        public static string Capitalize(this string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);
        }
    }
}