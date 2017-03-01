using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EnumGeneration.Domain
{
    using System.ComponentModel;

    public static class Extensions
    {
        public static string ToDescription(this Enum source)
        {
            var field = source.GetType().GetField(source.ToString());
            if (field != null)
            {
                var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                return attribute == null ? source.ToSpacedString() : attribute.Description;
            }
            return string.Empty;
        }

        public static string ToSpacedString(this Enum source)
        {
            return source.ToString().PascalToSpacedString();
        }

        /// <summary>
        /// Takes in a Pascal Case string and spaces between the words
        /// </summary>
        /// <param name="input">The string to replace</param>
        /// <returns>The replaced string</returns>
        public static string PascalToSpacedString(this string input)
        {
            return Regex.Replace(input, @"([a-z](?=[A-Z])|[A-Z](?=[A-Z][a-z]))", "$1 ");
        }
    }
}
