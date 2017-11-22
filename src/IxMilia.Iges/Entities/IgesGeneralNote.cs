// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MathNet.Spatial.Euclidean;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IxMilia.Iges.Entities
{
    public class IgesTextString
    {
        public double BoxWidth { get; set; }
        public double BoxHeight { get; set; }
        public int FontCode { get; set; }
        public IgesTextFontDefinition TextFontDefinition { get; set; }

        /// <summary>
        /// The slant angle in radians.  <see cref="Math.PI"/> / 2.0 is the value for no slant and is the default.
        /// </summary>
        public double SlantAngle { get; set; }

        /// <summary>
        /// The rotation angle in radians.
        /// </summary>
        public double RotationAngle { get; set; }

        public IgesTextMirroringAxis MirroringAxis { get; set; }
        public IgesTextRotationType RotationType { get; set; }
        public Point3D Location { get; set; }
        public string Value { get; set; }

        public IgesTextString()
        {
            SlantAngle = Math.PI / 2.0;
            Location = Point3D.Origin;
        }

        internal static IgesTextString ReadParameters(List<string> parameters, IgesReaderBinder binder, ref int index)
        {
            var str = new IgesTextString();
            str.PopulateFromParameters(parameters, binder, ref index);
            return str;
        }

        internal void PopulateFromParameters(List<string> parameters, IgesReaderBinder binder, ref int index)
        {
            var charCount = IgesParameterReader.Integer(parameters, ref index);
            BoxWidth = IgesParameterReader.Double(parameters, ref index);
            BoxHeight = IgesParameterReader.Double(parameters, ref index);

            var fontCode = IgesParameterReader.Integer(parameters, ref index, 1);
            if (fontCode < 0)
            {
                binder.BindEntity(-fontCode, e => TextFontDefinition = e as IgesTextFontDefinition);
                FontCode = -1;
            }
            else
            {
                FontCode = fontCode;
            }

            SlantAngle = IgesParameterReader.Double(parameters, ref index);
            RotationAngle = IgesParameterReader.Double(parameters, ref index);
            MirroringAxis = (IgesTextMirroringAxis)IgesParameterReader.Integer(parameters, ref index);
            RotationType = (IgesTextRotationType)IgesParameterReader.Integer(parameters, ref index);
            Location = IgesPoint.Point3D(parameters, ref index);
            Value = IgesParameterReader.String(parameters, ref index);
        }

        internal virtual void WriteParameters(List<object> parameters, IgesWriterBinder binder)
        {
            parameters.Add(Value?.Length ?? 0);
            parameters.Add(BoxWidth);
            parameters.Add(BoxHeight);

            if (TextFontDefinition != null)
            {
                parameters.Add(-binder.GetEntityId(TextFontDefinition));
            }
            else
            {
                parameters.Add(FontCode);
            }

            parameters.Add(SlantAngle);
            parameters.Add(RotationAngle);
            parameters.Add((int)MirroringAxis);
            parameters.Add((int)RotationType);
            parameters.Add(Location.X);
            parameters.Add(Location.Y);
            parameters.Add(Location.Z);
            parameters.Add(Value);
        }
    }

    public enum IgesGeneralNoteType
    {
        Simple = 0,
        DualStack = 1,
        ImbeddedFontChange = 2,
        Superscript = 3,
        Subscript = 4,
        SuperscriptSubscript = 5,
        MultipleStackLeftJustified = 6,
        MultipleStackCenterJustified = 7,
        MultipleStackRightJustified = 8,
        SimpleFraction = 100,
        DualStackFraction = 101,
        ImbeddedFontChangeDoubleFraction = 102,
        SuperscriptSubscriptFraction = 105
    }

    public class IgesGeneralNote : IgesEntity
    {
        public override IgesEntityType EntityType { get { return IgesEntityType.GeneralNote; } }

        public List<IgesTextString> Strings { get; private set; }

        public IgesGeneralNoteType NoteType
        {
            get { return (IgesGeneralNoteType)FormNumber; }
            set { FormNumber = (int)value; }
        }

        public IgesGeneralNote(IgesFile file)
            : base(file)
        {
            EntityUseFlag = IgesEntityUseFlag.Annotation;
            Strings = new List<IgesTextString>();
        }

        internal override int ReadParameters(List<string> parameters, IgesReaderBinder binder)
        {
            var index = 0;
            var stringCount = Integer(parameters, ref index);
            for (int i = 0; i < stringCount; i++)
            {
                Strings.Add(IgesTextString.ReadParameters(parameters, binder, ref index));
            }

            return index;
        }

        internal override IEnumerable<IgesEntity> GetReferencedEntities()
        {
            return Strings.Select(s => s?.TextFontDefinition);
        }

        internal override void WriteParameters(List<object> parameters, IgesWriterBinder binder)
        {
            parameters.Add(Strings.Count);
            for (int i = 0; i < Strings.Count; i++)
            {
                Strings[i].WriteParameters(parameters, binder);
            }
        }
    }
}
