// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MathNet.Spatial.Euclidean;
using System.Collections.Generic;

namespace IxMilia.Iges.Entities
{
    public partial class IgesTorus : IgesEntity
    {
        public override IgesEntityType EntityType { get { return IgesEntityType.Torus; } }

        // properties
        public double RingRadius { get; set; }
        public double DiscRadius { get; set; }
        public Point3D Center { get; set; }
        public Vector3D Normal { get; set; }

        public IgesTorus(IgesFile file)
            : this(file, 0.0, 0.0, Point3D.Origin, IgesVector.ZAxis)
        {
        }

        public IgesTorus(IgesFile file, double ringRadius, double discRadius, Point3D center, Vector3D normal)
            : base(file)
        {
            this.BlankStatus = IgesBlankStatus.Visible;
            this.SubordinateEntitySwitchType = IgesSubordinateEntitySwitchType.Independent;
            this.EntityUseFlag = IgesEntityUseFlag.Geometry;
            this.Hierarchy = IgesHierarchy.GlobalTopDown;
            this.RingRadius = ringRadius;
            this.DiscRadius = discRadius;
            this.Center = center;
            this.Normal = normal;
        }

        internal override int ReadParameters(List<string> parameters, IgesReaderBinder binder)
        {
            this.RingRadius = Double(parameters, 0);
            this.DiscRadius = Double(parameters, 1);
            this.Center = IgesPoint.Point3D(parameters, 2);
            this.Normal = IgesVector.ReadZAxis(parameters, 5);
            return 8;
        }

        internal override void WriteParameters(List<object> parameters, IgesWriterBinder binder)
        {
            parameters.Add(this.RingRadius);
            parameters.Add(this.DiscRadius);

            if (Center != Point3D.Origin || Normal != IgesVector.ZAxis)
            {
                parameters.Add(this.Center.X);
                parameters.Add(this.Center.Y);
                parameters.Add(this.Center.Z);
                if (Normal != IgesVector.ZAxis)
                {
                    parameters.Add(this.Normal.X);
                    parameters.Add(this.Normal.Y);
                    parameters.Add(this.Normal.Z);
                }
            }
        }
    }
}
