using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Extensions
{
    public static class StringExtensions
    {
        public static string NormalizeID(this string value)
        {
            return value?.Trim().ToUpperInvariant() ?? string.Empty;
        }
        public static bool IsPhoneValid(this string value)
        {
            for (var i = 0; i < value.Length; i++) 
            {
                if (char.IsDigit(value[i]))
                    return true;
            }
            return false;
        }
        public static bool IsEmailValid(this string value)
        {
            bool hasAt = false;
            bool hasDot = false;
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] == '@') hasAt = true;
                if (value[i]== '.') hasDot = true;
            }

            return hasAt && hasDot;
        }
    }
}
