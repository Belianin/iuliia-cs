using System.Globalization;

namespace Iuliia.Dto
{
    internal static class StringExtensions
    {
        public static string Capitalize(this string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);
        }
    }
}