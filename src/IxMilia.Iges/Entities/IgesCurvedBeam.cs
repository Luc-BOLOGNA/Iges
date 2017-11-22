// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MathNet.Spatial.Euclidean;

namespace IxMilia.Iges.Entities
{
    public class IgesCurvedBeam : IgesFiniteElement
    {
        public override IgesElementEdgeOrder EdgeOrder { get { return IgesElementEdgeOrder.Parabolic; } }

        public Point3D P1 { get; set; }
        public Point3D P2 { get; set; }

        public IgesCurvedBeam(
            IgesFile file,
            Point3D p1,
            Point3D p2)
            : base(file, IgesTopologyType.CurvedBeam)
        {
            P1 = p1;
            P2 = p2;
        }

        protected override void AddNodes()
        {
            InternalNodes.Add(new IgesNode(File, P1));
            InternalNodes.Add(new IgesNode(File, P2));
        }

        internal static IgesCurvedBeam FromDummy(IgesFiniteElementDummy dummy)
        {
            return new IgesCurvedBeam(
                dummy.File,
                GetNodeOffset(dummy, 0),
                GetNodeOffset(dummy, 1));
        }
    }
}
