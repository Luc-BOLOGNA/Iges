// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MathNet.Spatial.Euclidean;
using System.Collections.Generic;

namespace IxMilia.Iges.Entities
{
    public enum IgesArrowType
    {
        Wedge = 1,
        Triangle = 2,
        FilledTriangle = 3,
        None = 4,
        Circle = 5,
        FilledCircle = 6,
        Rectangle = 7,
        FilledRectangle = 8,
        Slash = 9,
        IntegralSign = 10,
        OpenTriangle = 11,
        DimensionOrigin = 12
    }

    public class IgesLeader : IgesEntity
    {
        public override IgesEntityType EntityType {  get { return IgesEntityType.Leader; } }

        public double ArrowHeight { get; set; }
        public double ArrowWidth { get; set; }

        public Point3D ArrowheadCoordinates { get; set; }
        public List<Point3D> LineSegments { get; private set; }

        public IgesArrowType ArrowType
        {
            get { return (IgesArrowType)FormNumber; }
            set { FormNumber = (int)value; }
        }

        public IgesLeader(IgesFile file)
            : base(file)
        {
            ArrowType = IgesArrowType.Wedge;
            EntityUseFlag = IgesEntityUseFlag.Annotation;
            ArrowheadCoordinates = Point3D.Origin;
            LineSegments = new List<Point3D>();
        }

        internal override int ReadParameters(List<string> parameters, IgesReaderBinder binder)
        {
            var index = 0;
            var segmentCount = Integer(parameters, ref index);
            ArrowHeight = Double(parameters, ref index);
            ArrowWidth = Double(parameters, ref index);
            var zDepth = Double(parameters, ref index);
            var x = Double(parameters, ref index);
            var y = Double(parameters, ref index);
            ArrowheadCoordinates = new Point3D(x, y, zDepth);
            for (int i = 0; i < segmentCount; i++)
            {
                x = Double(parameters, ref index);
                y = Double(parameters, ref index);
                LineSegments.Add(new Point3D(x, y, zDepth));
            }

            return segmentCount * 2 + 6;
        }

        internal override void WriteParameters(List<object> parameters, IgesWriterBinder binder)
        {
            parameters.Add(LineSegments.Count);
            parameters.Add(ArrowHeight);
            parameters.Add(ArrowWidth);
            parameters.Add(ArrowheadCoordinates.Z);
            parameters.Add(ArrowheadCoordinates.X);
            parameters.Add(ArrowheadCoordinates.Y);
            foreach (var p in LineSegments)
            {
                parameters.Add(p.X);
                parameters.Add(p.Y);
            }
        }
    }
}
