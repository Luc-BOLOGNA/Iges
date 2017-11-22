// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MathNet.Spatial.Euclidean;
using System.Collections.Generic;

namespace IxMilia.Iges.Entities
{
    public class IgesRightAngularWedge : IgesEntity
    {
        public IgesRightAngularWedge(IgesFile file)
            : base(file)
        {
         Corner  = Point3D.Origin;
         XAxis  = IgesVector.XAxis;
         ZAxis  = IgesVector.ZAxis;
        }

        public override IgesEntityType EntityType { get { return IgesEntityType.RightAngularWedge; } }

        public double XAxisSize { get; set; }
        public double YAxisSize { get; set; }
        public double ZAxisSize { get; set; }
        public double XAxisSizeAtYDistance { get; set; }
        public Point3D Corner { get; set; } 
        public Vector3D XAxis { get; set; } 
        public Vector3D ZAxis { get; set; }

        internal override int ReadParameters(List<string> parameters, IgesReaderBinder binder)
        {
            XAxisSize = Double(parameters, 0);
            YAxisSize = Double(parameters, 1);
            ZAxisSize = Double(parameters, 2);
            XAxisSizeAtYDistance = Double(parameters, 3);
            Corner = IgesPoint.Point3D(parameters, 4);
            XAxis = IgesVector.Vector3D(parameters, 7);
            ZAxis = IgesVector.Vector3D(parameters, 10);
            return 13;
        }

        internal override void WriteParameters(List<object> parameters, IgesWriterBinder binder)
        {
            parameters.Add(XAxisSize);
            parameters.Add(YAxisSize);
            parameters.Add(ZAxisSize);
            parameters.Add(XAxisSizeAtYDistance);
            parameters.Add(Corner.X);
            parameters.Add(Corner.Y);
            parameters.Add(Corner.Z);
            parameters.Add(XAxis.X);
            parameters.Add(XAxis.Y);
            parameters.Add(XAxis.Z);
            parameters.Add(ZAxis.X);
            parameters.Add(ZAxis.Y);
            parameters.Add(ZAxis.Z);
        }
    }
}
