// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MathNet.Spatial.Euclidean;
using System.Collections.Generic;

namespace IxMilia.Iges.Entities
{
    public class IgesEllipsoid : IgesEntity
    {
        public override IgesEntityType EntityType { get { return IgesEntityType.Ellipsoid; } }

        public double XAxisLength { get; set; }
        public double YAxisLength { get; set; }
        public double ZAxisLength { get; set; }
        public Point3D Center { get; set; }
        public Vector3D XAxis { get; set; }
        public Vector3D ZAxis { get; set; }

        public IgesEllipsoid(IgesFile file)
            : base(file)
        {
            EntityUseFlag = IgesEntityUseFlag.Geometry;
            Center = Point3D.Origin;
            XAxis = IgesVector.XAxis;
            ZAxis = IgesVector.ZAxis;
        }

        internal override int ReadParameters(List<string> parameters, IgesReaderBinder binder)
        {
            int index = 0;
            XAxisLength = Double(parameters, ref index);
            YAxisLength = Double(parameters, ref index);
            ZAxisLength = Double(parameters, ref index);
            Center = IgesPoint.Point3D(parameters, ref index);
            XAxis = IgesVector.ReadXAxis(parameters, ref index);
            ZAxis = IgesVector.ReadZAxis(parameters, ref index);
            return index;
        }

        internal override void WriteParameters(List<object> parameters, IgesWriterBinder binder)
        {
            parameters.Add(XAxisLength);
            parameters.Add(YAxisLength);
            parameters.Add(ZAxisLength);
            parameters.Add(Center.X);
            parameters.Add(Center.Y);
            parameters.Add(Center.Z);
            parameters.Add(XAxis.X);
            parameters.Add(XAxis.Y);
            parameters.Add(XAxis.Z);
            parameters.Add(ZAxis.X);
            parameters.Add(ZAxis.Y);
            parameters.Add(ZAxis.Z);
        }
    }
}
