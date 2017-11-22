// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using IxMilia.Iges.Entities;

namespace IxMilia.Iges
{
    public class IgesFile
    {
        internal const int MaxDataLength = 72;
        internal const int MaxParameterLength = 64;

        public const char DefaultFieldDelimiter = ',';
        public const char DefaultRecordDelimiter = ';';
        public const int DefaultIntegerSize = 32;
        public const int DefaultSingleSize = 8;
        public const int DefaultDecimalDigits = 23;
        public const int DefaultDoubleMagnitude = 11;
        public const int DefaultDoublePrecision = 52;
        public const double DefaultModelSpaceScale = 1.0;
        public const IgesUnits DefaultModelUnits = IgesUnits.Inches;
        public const int DefaultMaxLineWeightGraduations = 2000;
        public const double DefaultMaxLineWeight = 2.0;
        public const double DefaultMinimumResolution = 1.0e-10;
        public const IgesVersion DefaultIgesVersion = IgesVersion.v5_3;
        public const IgesDraftingStandard DefaultDraftingStandard = IgesDraftingStandard.None;

        public const char StringSentinelCharacter = 'H';

        public char FieldDelimiter;
        public char RecordDelimiter;
        public string Identification;
        public string FullFileName;
        public string SystemIdentifier;
        public string SystemVersion;
        public int IntegerSize;
        public int SingleSize;
        public int DecimalDigits;
        public int DoubleMagnitude;
        public int DoublePrecision;
        public string Identifier;
        public double ModelSpaceScale;
        public IgesUnits ModelUnits;
        public string CustomModelUnits;
        private int _MaxLineWeightGraduations;
        public int MaxLineWeightGraduations
        {
            get => _MaxLineWeightGraduations;
            set
            {
                _MaxLineWeightGraduations = value;
                MaxLineWeightFactor = _MaxLineWeight / _MaxLineWeightGraduations;
            }
        }
        private double _MaxLineWeight;
        public double MaxLineWeight
        {
            get => _MaxLineWeight;
            set
            {
                _MaxLineWeight = value;
                MaxLineWeightFactor = _MaxLineWeight / _MaxLineWeightGraduations;
            }
        }

        public double MaxLineWeightFactor { get; private set; }
        public DateTime TimeStamp;
        public double MinimumResolution;
        public double MaxCoordinateValue;
        public string Author;
        public string Organization;
        public IgesVersion IgesVersion;
        public IgesDraftingStandard DraftingStandard;
        public DateTime ModifiedTime;
        public string ApplicationProtocol;

        public readonly List<IgesEntity> Entities = new List<IgesEntity>();

        public IgesFile()
        {
            FieldDelimiter = DefaultFieldDelimiter;
            RecordDelimiter = DefaultRecordDelimiter;
            IntegerSize = DefaultIntegerSize;
            SingleSize = DefaultSingleSize;
            DecimalDigits = DefaultDecimalDigits;
            DoubleMagnitude = DefaultDoubleMagnitude;
            DoublePrecision = DefaultDoublePrecision;
            ModelSpaceScale = DefaultModelSpaceScale;
            ModelUnits = DefaultModelUnits;
            MaxLineWeightGraduations = DefaultMaxLineWeightGraduations;
            MaxLineWeight = DefaultMaxLineWeight;
            MinimumResolution = DefaultMinimumResolution;
            DraftingStandard = DefaultDraftingStandard;
        }

        public IgesFile(
                char fieldDelimiter,
                char recordDelimiter,
                string identification,
                string fullFileName,
                string systemIdentifier,
                string SystemVersion,
                int integerSize,
                int singleSize,
                int decimalDigits,
                int doubleMagnitude,
                int doublePrecision,
                string identifier,
                double modelSpaceScale,
                IgesUnits modelUnits,
                string customModelUnits,
                int maxLineWeightGraduations,
                double maxLineWeight,
                DateTime timeStamp,
                double minimumResolution,
                double maxCoordinateValue,
                string author,
                string organization,
                IgesVersion igesVersion,
                IgesDraftingStandard draftingStandard,
                DateTime modifiedTime,
                string applicationProtocol
                )
        {
            if (fieldDelimiter == recordDelimiter)
                throw new IgesException("Record delimiter cannot match field delimiter");
            this.FieldDelimiter = fieldDelimiter; // 1
            this.RecordDelimiter = recordDelimiter; // 2
            this.Identification = identification; // 3
            this.FullFileName = fullFileName; // 4
            this.SystemIdentifier = systemIdentifier; // 5
            this.SystemVersion = SystemVersion; // 6
            this.IntegerSize = integerSize; // 7
            this.SingleSize = singleSize; // 8
            this.DecimalDigits = decimalDigits; // 9
            this.DoubleMagnitude = doubleMagnitude; // 10
            this.DoublePrecision = doublePrecision; // 11
            this.Identifier = identifier; // 12
            this.ModelSpaceScale = modelSpaceScale; // 13
            this.ModelUnits = modelUnits; // 14
            this.CustomModelUnits = customModelUnits; // 15
            this.MaxLineWeightGraduations = maxLineWeightGraduations; // 16
            this.MaxLineWeight = maxLineWeight; // 17
            this.TimeStamp = timeStamp; // 18
            this.MinimumResolution = minimumResolution; // 19
            this.MaxCoordinateValue = maxCoordinateValue; // 20
            this.Author = author; // 21
            this.Organization = organization; // 22
            this.IgesVersion = igesVersion; // 23
            this.DraftingStandard = draftingStandard; // 24
            this.ModifiedTime = modifiedTime; // 25
            this.ApplicationProtocol = applicationProtocol; // 26

        }

        public void Save(string filename)
        {
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Write, FileShare.None))
            {
                Save(fs);
            }
        }

        public void Save(Stream stream)
        {
            new IgesFileWriter().Write(this, stream);
        }


        public static IgesFile Load(string filename)
        {
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                return Load(fs);
            }
        }

        public static IgesFile Load(Stream stream)
        {
            return IgesFileReader.Load(stream);
        }
    }
}
