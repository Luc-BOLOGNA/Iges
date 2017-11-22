// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace IxMilia.Iges
{
    internal static class IgesParameterReader
    {
        public static double Double(List<string> values, ref int index, double defaultValue = 0.0)
        {
            return Double(values, index++, defaultValue);
        }
        public static double Double(List<string> values, int index, double defaultValue = 0.0)
        {
            if (index < values.Count)
            {
                var result = 0.0;
                double.TryParse(values[index], out result);
                return result;
            }
            else
            {
                return defaultValue;
            }
        }

        public static int Integer(List<string> values, ref int index, int defaultValue = 0)
        {
            return Integer(values, index++, defaultValue);
        }
        public static int Integer(List<string> values, int index, int defaultValue = 0)
        {
            if (index < values.Count)
            {
                var result = 0;
                int.TryParse(values[index], out result);
                return result;
            }
            else
            {
                return defaultValue;
            }
        }

        public static string String(List<string> values, ref int index, string defaultValue = null)
        {
            return String(values, index++, defaultValue);
        }
        public static string String(List<string> values, int index, string defaultValue = null)
        {
            return (index < values.Count) ? values[index] : defaultValue;
        }

        public static bool Boolean(List<string> values, ref int index, bool defaultValue = false)
        {
            return Boolean(values, index++, defaultValue);
        }

        public static bool Boolean(List<string> values, int index, bool defaultValue = false)
        {
            return (index < values.Count) ? Integer(values, index) != 0 : defaultValue;
        }

        public static DateTime DateTime(List<string> values, ref int index)
        {
            return DateTime(values, ref index, System.DateTime.MinValue);
        }
        public static DateTime DateTime(List<string> values, int index)
        {
            return DateTime(values, index, System.DateTime.MinValue);
        }


        public static DateTime DateTime(List<string> values, ref int index, DateTime defaultValue)
        {
            return DateTime(values, index++, defaultValue);
        }
        public static DateTime DateTime(List<string> values, int index, DateTime defaultValue)
        {
            return (index < values.Count) ? IgesFileReader.ParseDateTime(values[index], defaultValue) : defaultValue;
        }
    }
}
