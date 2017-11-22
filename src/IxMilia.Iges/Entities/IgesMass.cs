// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MathNet.Spatial.Euclidean;

namespace IxMilia.Iges.Entities
{
    public class IgesMass : IgesFiniteElement
    {
        public override IgesElementEdgeOrder EdgeOrder { get { return IgesElementEdgeOrder.NotApplicable; } }

        public Point3D Location { get; set; }

        public IgesMass(
            IgesFile file,
            Point3D location)
            : base(file, IgesTopologyType.Mass)
        {
            Location = location;
        }

        protected override void AddNodes()
        {
            InternalNodes.Add(new IgesNode(File, Location));
        }

        internal static IgesMass FromDummy(IgesFiniteElementDummy dummy)
        {
            return new IgesMass(
                dummy.File,
                GetNodeOffset(dummy, 0));
        }
    }
}
