// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MathNet.Spatial.Euclidean;
using System.Collections.Generic;

namespace IxMilia.Iges.Entities
{
    public class IgesRightCircularConeFrustrum : IgesEntity
    {
        public IgesRightCircularConeFrustrum(IgesFile file)
            : base(file)
        {
        }

        public override IgesEntityType EntityType { get { return IgesEntityType.RightCircularConeFrustrum; } }

        public double Height { get; set; }
        public double LargeFaceRadius { get; set; }
        public double SmallFaceRadius { get; set; }
        public Point3D LargeFaceCenter { get; set; } = Point3D.Origin;
        public Vector3D AxisDirection { get; set; } = IgesVector.ZAxis;

        internal override int ReadParameters(List<string> parameters, IgesReaderBinder binder)
        {
            Height = Double(parameters, 0);
            LargeFaceRadius = Double(parameters, 1);
            SmallFaceRadius = Double(parameters, 2);
            LargeFaceCenter = IgesPoint.Point3D(parameters, 3);
            AxisDirection = IgesVector.Vector3D(parameters, 6);
            return 9;
        }

        internal override void WriteParameters(List<object> parameters, IgesWriterBinder binder)
        {
            parameters.Add(Height);
            parameters.Add(LargeFaceRadius);
            parameters.Add(SmallFaceRadius);
            parameters.Add(LargeFaceCenter.X);
            parameters.Add(LargeFaceCenter.Y);
            parameters.Add(LargeFaceCenter.Z);
            parameters.Add(AxisDirection.X);
            parameters.Add(AxisDirection.Y);
            parameters.Add(AxisDirection.Z);
        }
    }
}
