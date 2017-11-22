// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MathNet.Spatial.Euclidean;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace IxMilia.Iges.Entities
{
    public class IgesCircularArc : IgesEntity, IIgesDrawable2D
    {
        public override IgesEntityType EntityType { get { return IgesEntityType.CircularArc; } }

        // properties
        public double PlaneDisplacement { get; set; }
        public Point2D Center { get; set; }
        public Point2D StartPoint { get; set; }
        public Point2D EndPoint { get; set; }

        // custom properties
        public Point3D ProperCenter
        {
            get
            {
                return new Point3D(Center.X, Center.Y, PlaneDisplacement);
            }
        }

        public Point3D ProperStartPoint
        {
            get
            {
                return new Point3D(StartPoint.X, StartPoint.Y, PlaneDisplacement);
            }
        }

        public Point3D ProperEndPoint
        {
            get
            {
                return new Point3D(EndPoint.X, EndPoint.Y, PlaneDisplacement);
            }
        }

        public IgesCircularArc(IgesFile file)
            : this(Point3D.Origin, Point3D.Origin, Point3D.Origin, file)
        {
        }

        public IgesCircularArc(Point3D center, Point3D start, Point3D end, IgesFile file)
            : this(center, new Point2D(start.X, start.Y), new Point2D(end.X, end.Y), file)
        {
            Debug.Assert(center.Z == start.Z && center.Z == end.Z, "All z values must be equal");
        }

        public IgesCircularArc(Point3D center, Point2D start, Point2D end, IgesFile file)
            : base(file)
        {
            this.PlaneDisplacement = center.Z;
            this.Center = new Point2D(center.X, center.Y);
            this.StartPoint = start;
            this.EndPoint = end;
        }

        internal override int ReadParameters(List<string> parameters, IgesReaderBinder binder)
        {
            this.PlaneDisplacement = Double(parameters, 0);
            this.Center = IgesPoint.Point2D(parameters, 1);
            this.StartPoint = IgesPoint.Point2D(parameters, 3);
            this.EndPoint = IgesPoint.Point2D(parameters, 5);
            return 7;
        }

        internal override void WriteParameters(List<object> parameters, IgesWriterBinder binder)
        {
            parameters.Add(this.PlaneDisplacement);
            parameters.Add(this.Center.X);
            parameters.Add(this.Center.Y);
            parameters.Add(this.StartPoint.X);
            parameters.Add(this.StartPoint.Y);
            parameters.Add(this.EndPoint.X);
            parameters.Add(this.EndPoint.Y);
        }

        public IIgesDrawable2D Reverse()
        {
            Point2D tmp = StartPoint;
            StartPoint = EndPoint;
            EndPoint = tmp;
            return this;
        }

        public override string ToString()
        {
            return "Star: " + StartPoint.ToString() + ", End: " + EndPoint.ToString() + ", Center: " + Center.ToString();
        }
    }
}
