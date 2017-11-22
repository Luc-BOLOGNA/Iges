// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MathNet.Spatial.Euclidean;

namespace IxMilia.Iges.Entities
{
    public class IgesOffsetBeam : IgesFiniteElement
    {
        public override IgesElementEdgeOrder EdgeOrder { get { return IgesElementEdgeOrder.Linear; } }

        public Point3D Offset1 { get; set; }
        public Point3D Offset2 { get; set; }
        public Point3D P1 { get; set; }
        public Point3D P2 { get; set; }

        public IgesOffsetBeam(
            IgesFile file,
            Point3D offset1,
            Point3D offset2,
            Point3D p1,
            Point3D p2)
            : base(file, IgesTopologyType.OffsetBeam)
        {
            Offset1 = offset1;
            Offset2 = offset2;
            P1 = p1;
            P2 = p2;
        }

        protected override void AddNodes()
        {
            InternalNodes.Add(new IgesNode(File, Offset1));
            InternalNodes.Add(new IgesNode(File, Offset2));
            InternalNodes.Add(new IgesNode(File, P1));
            InternalNodes.Add(new IgesNode(File, P2));
        }

        internal static IgesOffsetBeam FromDummy(IgesFiniteElementDummy dummy)
        {
            return new IgesOffsetBeam(
                dummy.File,
                GetNodeOffset(dummy, 0),
                GetNodeOffset(dummy, 1),
                GetNodeOffset(dummy, 2),
                GetNodeOffset(dummy, 3));
        }
    }
}
