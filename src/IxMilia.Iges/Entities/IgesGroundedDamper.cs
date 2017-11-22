// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MathNet.Spatial.Euclidean;

namespace IxMilia.Iges.Entities
{
    public class IgesGroundedDamper : IgesFiniteElement
    {
        public override IgesElementEdgeOrder EdgeOrder { get { return IgesElementEdgeOrder.NotApplicable; } }

        public Point3D Location { get; set; }

        public IgesGroundedDamper(
            IgesFile file,
            Point3D location)
            : base(file, IgesTopologyType.GroundedDamper)
        {
            Location = location;
        }

        protected override void AddNodes()
        {
            InternalNodes.Add(new IgesNode(File, Location));
        }

        internal static IgesGroundedDamper FromDummy(IgesFiniteElementDummy dummy)
        {
            return new IgesGroundedDamper(
                dummy.File,
                GetNodeOffset(dummy, 0));
        }
    }
}
