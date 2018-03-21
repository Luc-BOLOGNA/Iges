// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using IxMilia.Iges.Entities;

namespace IxMilia.Iges
{
    internal class IgesDirectoryData
    {
        public readonly IgesFile File;

        public IgesEntityType EntityType { get; set; }
        public int ParameterPointer { get; set; }
        public int Structure { get; set; }
        public int LineFontPattern { get; set; }
        public int Level { get; set; }
        public int View { get; set; }
        public int TransformationMatrixPointer { get; set; }
        public int LableDisplay { get; set; }
        public string StatusNumber { get; set; }
        public int SequenceNumber { get; set; }

        public int LineWeight { get; set; }
        public int Color { get; set; }
        public int LineCount { get; set; }
        public int FormNumber { get; set; }
        public string EntityLabel { get; set; }
        public uint EntitySubscript { get; set; }

        private const string BlankField = "        ";

        public void ToString(List<string> directoryLines)
        {
            var line1 = string.Format(
                "{0,8}{1,8}{2,8}{3,8}{4,8}{5,8}{6,8}{7,8}{8,8}",
                (int)EntityType,
                ParameterPointer,
                Structure,
                LineFontPattern,
                Level,
                ToStringOrDefault(View),
                ToStringOrDefault(TransformationMatrixPointer),
                ToStringOrDefault(LableDisplay),
                StatusNumber ?? "0");
            var line2 = string.Format(
                "{0,8}{1,8}{2,8}{3,8}{4,8}{5,8}{6,8}{7,8}{8,8}",
                (int)EntityType,
                LineWeight,
                Color,
                LineCount,
                FormNumber,
                BlankField, // reserved field 16
                BlankField, // reserved field 17
                ToStringOrDefault(EntityLabel),
                ToStringOrDefault(EntitySubscript));
            directoryLines.Add(line1);
            directoryLines.Add(line2);
        }

        private static string ToStringOrDefault(int value)
        {
            return value == 0
                ? BlankField
                : string.Format("{0,8}", value);
        }

        private static string ToStringOrDefault(uint value)
        {
            return value == 0u
                ? BlankField
                : string.Format("{0,8}", value);
        }

        private static string ToStringOrDefault(string value)
        {
            return string.IsNullOrWhiteSpace(value)
                ? BlankField
                : value.Substring(0, Math.Min(8, value.Length));
        }

        public static IgesDirectoryData FromRawLines(IgesFile file, string line1, string line2)
        {
            var dir = new IgesDirectoryData(file);
            dir.EntityType = (IgesEntityType)GetField(line1, 1).ToInt();
            dir.ParameterPointer = GetField(line1, 2).ToInt();
            dir.Structure = GetField(line1, 3).ToInt();
            dir.LineFontPattern = GetField(line1, 4).ToInt();
            dir.Level = GetField(line1, 5).ToInt();
            dir.View = GetField(line1, 6).ToInt();
            dir.TransformationMatrixPointer = GetField(line1, 7).ToInt();
            dir.LableDisplay = GetField(line1, 8).ToInt();
            dir.StatusNumber = GetField(line1, 9);

            dir.LineWeight = GetField(line2, 2).ToInt();
            dir.Color = GetField(line2, 3).ToInt();
            dir.LineCount = GetField(line2, 4).ToInt();
            dir.FormNumber = GetField(line2, 5).ToInt();
            dir.EntityLabel = GetField(line2, 8, null);
            dir.EntitySubscript = GetField(line2, 9).ToUInt();
            return dir;
        }

        const int FieldSize = 8;

        public IgesDirectoryData(IgesFile file)
        {
            File = file;
        }

        private static string GetField(string str, int field, string defaultValue = "0")
        {
            var offset = (field - 1) * FieldSize;
            var value = str.Substring(offset, FieldSize).Trim();
            return string.IsNullOrEmpty(value) ? defaultValue : value;
        }
    }
}
