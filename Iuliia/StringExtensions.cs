using System;

namespace Iuliia
{
    internal static class StringExtensions
    {
        public static string Capitalize(this string str)
        {
            if (str == null)
                return null;
            if (str.Length < 2)
                return str.ToUpper();
            return $"{char.ToUpper(str[0])}{str.Substring(1)}";
        }
    }
}