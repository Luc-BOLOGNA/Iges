// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MathNet.Spatial.Euclidean;
using System.Collections.Generic;

namespace IxMilia.Iges.Entities
{
    public partial class IgesSphere : IgesEntity
    {
        public override IgesEntityType EntityType { get { return IgesEntityType.Sphere; } }

        // properties
        public double Radius { get; set; }
        public Point3D Center { get; set; }

        public IgesSphere(IgesFile file)
            : this(file, 0.0, Point3D.Origin)
        {
        }

        public IgesSphere(IgesFile file, double radius, Point3D center)
            : base(file)
        {
            this.EntityUseFlag = IgesEntityUseFlag.Geometry;
            this.Radius = radius;
            this.Center = center;
        }

        internal override int ReadParameters(List<string> parameters, IgesReaderBinder binder)
        {
            this.Radius = Double(parameters, 0);
            this.Center = IgesPoint.Point3D(parameters, 1);
            return 4;
        }

        internal override void WriteParameters(List<object> parameters, IgesWriterBinder binder)
        {
            parameters.Add(this.Radius);
            if (Center != Point3D.Origin)
            {
                parameters.Add(this.Center.X);
                parameters.Add(this.Center.Y);
                parameters.Add(this.Center.Z);
            }
        }
    }
}
