// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MathNet.Spatial.Euclidean;
using System.Collections.Generic;

namespace IxMilia.Iges.Entities
{
    public class IgesBlock : IgesEntity
    {
        public IgesBlock(IgesFile file) : base(file)
        {
            Corner = Point3D.Origin;
            XAxis = IgesVector.XAxis;
            ZAxis = IgesVector.ZAxis;
        }

    public override IgesEntityType EntityType { get { return IgesEntityType.Block; } }

        public double XLength { get; set; }
        public double YLength { get; set; }
        public double ZLength { get; set; }
        public Point3D Corner { get; set; } 
        public Vector3D XAxis { get; set; } 
        public Vector3D ZAxis { get; set; } 

        internal override int ReadParameters(List<string> parameters, IgesReaderBinder binder)
        {
            int index = 0;
            XLength = Double(parameters, ref index);
            YLength = Double(parameters, ref index);
            ZLength = Double(parameters, ref index);
            Corner = IgesPoint.Point3D(parameters, ref index);
            XAxis = IgesVector.ReadXAxis(parameters, ref index);
            ZAxis = IgesVector.ReadZAxis(parameters, ref index);
            return index;
        }

        internal override void WriteParameters(List<object> parameters, IgesWriterBinder binder)
        {
            parameters.Add(XLength);
            parameters.Add(YLength);
            parameters.Add(ZLength);
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
