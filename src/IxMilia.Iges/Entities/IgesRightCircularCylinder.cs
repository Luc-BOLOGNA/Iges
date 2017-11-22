// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MathNet.Spatial.Euclidean;
using System.Collections.Generic;

namespace IxMilia.Iges.Entities
{
    public class IgesRightCircularCylinder : IgesEntity
    {
        public IgesRightCircularCylinder(IgesFile file)
            : base(file)
        {
        }

        public override IgesEntityType EntityType { get { return IgesEntityType.RightCircularCylinder; } }

        public double Height { get; set; }
        public double Radius { get; set; }
        public Point3D FirstFaceCenter { get; set; } = Point3D.Origin;
        public Vector3D AxisDirection { get; set; } = IgesVector.ZAxis;

        internal override int ReadParameters(List<string> parameters, IgesReaderBinder binder)
        {
            Height = Double(parameters, 0);
            Radius = Double(parameters, 1);
            FirstFaceCenter = IgesPoint.Point3D(parameters, 2);
            AxisDirection = IgesVector.Vector3D(parameters, 5);
            return 8;
        }

        internal override void WriteParameters(List<object> parameters, IgesWriterBinder binder)
        {
            parameters.Add(Height);
            parameters.Add(Radius);
            parameters.Add(FirstFaceCenter.X);
            parameters.Add(FirstFaceCenter.Y);
            parameters.Add(FirstFaceCenter.Z);
            parameters.Add(AxisDirection.X);
            parameters.Add(AxisDirection.Y);
            parameters.Add(AxisDirection.Z);
        }
    }
}
