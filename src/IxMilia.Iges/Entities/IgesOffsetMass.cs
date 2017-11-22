// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MathNet.Spatial.Euclidean;

namespace IxMilia.Iges.Entities
{
    public class IgesOffsetMass : IgesFiniteElement
    {
        public override IgesElementEdgeOrder EdgeOrder { get { return IgesElementEdgeOrder.NotApplicable; } }

        public Point3D Location { get; set; }
        public Point3D CenterOfMass { get; set; }

        public IgesOffsetMass(
            IgesFile file,
            Point3D location,
            Point3D centerOfMass)
            : base(file, IgesTopologyType.OffsetMass)
        {
            Location = location;
            CenterOfMass = centerOfMass;
        }

        protected override void AddNodes()
        {
            InternalNodes.Add(new IgesNode(File, Location));
            InternalNodes.Add(new IgesNode(File, CenterOfMass));
        }

        internal static IgesOffsetMass FromDummy(IgesFiniteElementDummy dummy)
        {
            return new IgesOffsetMass(
                dummy.File,
                GetNodeOffset(dummy, 0),
                GetNodeOffset(dummy, 1));
        }
    }
}
