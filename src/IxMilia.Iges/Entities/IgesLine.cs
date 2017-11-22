// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MathNet.Spatial.Euclidean;
using System.Collections.Generic;

namespace IxMilia.Iges.Entities
{
    public enum IgesLineBounding
    {
        BoundOnBothSides = 0,
        BoundOnStart = 1,
        Unbounded = 2
    }

    public class IgesLine2D : IgesEntity, IIgesDrawable2D
    {
        public override IgesEntityType EntityType { get { return IgesEntityType.Line; } }

        // properties
        public Line2D Line { get; set; }
        public Point2D StartPoint => Line.StartPoint;
        public Point2D EndPoint => Line.EndPoint;

        public IIgesDrawable2D Reverse()
        {
            Line = new Line2D(Line.EndPoint, Line.StartPoint);
            return this;
        }

        // custom properties
        public IgesLineBounding Bounding
        {
            get
            {
                return (IgesLineBounding)FormNumber;
            }
            set
            {
                FormNumber = (int)value;
            }
        }

        public IgesLine2D(IgesFile file)
            : base(file) => this.Line = new Line2D();

        public IgesLine2D(IgesFile file, Point2D start, Point2D end)
            : base(file) => this.Line = new Line2D(start, end);

        internal override int ReadParameters(List<string> parameters, IgesReaderBinder binder)
        {
            this.Line = new Line2D(
                IgesPoint.Point2D(parameters, 0),
                IgesPoint.Point2D(parameters, 3));
            return 6;
        }

        internal override void WriteParameters(List<object> parameters, IgesWriterBinder binder)
        {
            this.StartPoint.WriteParameters(parameters, binder);
            this.EndPoint.WriteParameters(parameters, binder);
        }

        public override string ToString() => "Star: " + StartPoint.ToString() + ", End: " + EndPoint.ToString();
    }
}
