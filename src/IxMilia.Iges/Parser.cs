using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace IxMilia.Iges
{
    internal static class Parser
    {
        private static CultureInfo culture = CultureInfo.GetCultureInfo("en-US");
        /*
        public static int ToInt(this string value)
        {
            int result = 0;
            if (int.TryParse(value, out result))
                return result;
            else
                throw new FormatException("'" + value + "': Bad format of number");
        }

        public static uint ToUInt(this string value)
        {
            uint result = 0;
            if (uint.TryParse(value, out result))
                return result;
            else
                throw new FormatException("'" + value + "': Bad format of number");
        }

        public static double ToDouble(this string value)
        {
            double result = 0;
            if (double.TryParse(value, out result))
                return result;
            else
                throw new FormatException("'" + value + "': Bad format of number");
        }
        */

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
