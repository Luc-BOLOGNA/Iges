// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MathNet.Spatial.Euclidean;

namespace IxMilia.Iges.Entities
{
    public class IgesParabolicQuadrilateral : IgesFiniteElement
    {
        public override IgesElementEdgeOrder EdgeOrder { get { return IgesElementEdgeOrder.Parabolic; } }

        public Point3D P1 { get; set; }
        public Point3D P1P2Control { get; set; }
        public Point3D P2 { get; set; }
        public Point3D P2P3Control { get; set; }
        public Point3D P3 { get; set; }
        public Point3D P3P4Control { get; set; }
        public Point3D P4 { get; set; }
        public Point3D P4P1Control { get; set; }

        public IgesParabolicQuadrilateral(
            IgesFile file,
            Point3D p1,
            Point3D p1P2Control,
            Point3D p2,
            Point3D p2P3Control,
            Point3D p3,
            Point3D p3P4Control,
            Point3D p4,
            Point3D p4P1Control)
            : base(file, IgesTopologyType.ParabolicQuadrilateral)
        {
            P1 = p1;
            P1P2Control = p1P2Control;
            P2 = p2;
            P2P3Control = p2P3Control;
            P3 = p3;
            P3P4Control = p3P4Control;
            P4 = p4;
            P4P1Control = p4P1Control;
        }

        protected override void AddNodes()
        {
            InternalNodes.Add(new IgesNode(File, P1));
            InternalNodes.Add(new IgesNode(File, P1P2Control));
            InternalNodes.Add(new IgesNode(File, P2));
            InternalNodes.Add(new IgesNode(File, P2P3Control));
            InternalNodes.Add(new IgesNode(File, P3));
            InternalNodes.Add(new IgesNode(File, P3P4Control));
            InternalNodes.Add(new IgesNode(File, P4));
            InternalNodes.Add(new IgesNode(File, P4P1Control));
        }

        internal static IgesParabolicQuadrilateral FromDummy(IgesFiniteElementDummy dummy)
        {
            return new IgesParabolicQuadrilateral(
                dummy.File,
                GetNodeOffset(dummy, 0),
                GetNodeOffset(dummy, 1),
                GetNodeOffset(dummy, 2),
                GetNodeOffset(dummy, 3),
                GetNodeOffset(dummy, 4),
                GetNodeOffset(dummy, 5),
                GetNodeOffset(dummy, 6),
                GetNodeOffset(dummy, 7));
        }
    }
}
