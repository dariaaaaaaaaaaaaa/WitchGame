using System;
using System.Globalization;

namespace Core.Utils
{
    /// <summary>
    /// All String extensions.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Check Null or Empty string.
        /// </summary>
        /// <param name="string">Source string data.</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string @string)
        {
            return string.IsNullOrEmpty(@string);
        }
        
        public static bool IsNumeric(this string str)
        {
            foreach (var character in str)
            {
                if (!char.IsDigit(character))
                {
                    return false;
                }
            }

            return true;
        }

        public static string ToCurrencyString(this int value)
        {
            var newString = value.ToString("N", new CultureInfo("is-IS"));
            var result = string.Empty;
            foreach (var character in newString)
            {
                if (!character.Equals(','))
                {
                    result += character;
                }
                else
                {
                    break;
                }
            }

            return result;
        }
        
        public static string FormatTimerString(this TimeSpan timeLeft)
        {
            var days = "{0:%d} d ";
            var hours = "{0:%h} h ";
            var minutes = "{0:%m} m ";
            var seconds = "{0:%s} s ";

            var formattingString = string.Empty;

            if (timeLeft.Days > 0)
            {
                formattingString += days;
            }

            if (timeLeft.Hours > 0)
            {
                formattingString += hours;
            }

            if (timeLeft.Minutes > 0)
            {
                formattingString += minutes;
            }

            if (timeLeft.TotalMinutes > 0)
            {
                formattingString += seconds;
            }

            return string.Format(formattingString, timeLeft);
        }
    }
}