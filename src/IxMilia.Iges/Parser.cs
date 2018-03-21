using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace IxMilia.Iges
{
    internal static class Parser
    {
        private static CultureInfo culture = CultureInfo.GetCultureInfo("en-US");

        public static int ToInt(this string value)
        {
            try
            {
                return int.Parse(value, culture);
            }
            catch (FormatException fex)
            {
                throw new FormatException("'" + value + "': " + fex.Message);
            }
        }

        public static uint ToUInt(this string value)
        {
            try
            {
                return uint.Parse(value, culture);
            }
            catch (FormatException fex)
            {
                throw new FormatException("'" + value + "': " + fex.Message);
            }
        }

        public static double ToDouble(this string value)
        {
            try
            {
                return double.Parse(value, culture);
            }
            catch (FormatException fex)
            {
                throw new FormatException("'" + value + "': " + fex.Message);
            }
        }
    }
}
