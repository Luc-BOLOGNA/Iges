// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MathNet.Spatial.Euclidean;

namespace IxMilia.Iges.Entities
{
    public class IgesCubicQuadrilateral : IgesFiniteElement
    {
        public override IgesElementEdgeOrder EdgeOrder { get { return IgesElementEdgeOrder.Cubic; } }

        public Point3D P1 { get; set; }
        public Point3D P1P2Control1 { get; set; }
        public Point3D P1P2Control2 { get; set; }
        public Point3D P2 { get; set; }
        public Point3D P2P3Control1 { get; set; }
        public Point3D P2P3Control2 { get; set; }
        public Point3D P3 { get; set; }
        public Point3D P3P4Control1 { get; set; }
        public Point3D P3P4Control2 { get; set; }
        public Point3D P4 { get; set; }
        public Point3D P4P1Control1 { get; set; }
        public Point3D P4P1Control2 { get; set; }

        public IgesCubicQuadrilateral(
            IgesFile file,
            Point3D p1,
            Point3D p1P2Control1,
            Point3D p1P2Control2,
            Point3D p2,
            Point3D p2P3Control1,
            Point3D p2P3Control2,
            Point3D p3,
            Point3D p3P4Control1,
            Point3D p3P4Control2,
            Point3D p4,
            Point3D p4P1Control1,
            Point3D p4P1Control2)
            : base(file, IgesTopologyType.CubicQuadrilateral)
        {
            P1 = p1;
            P1P2Control1 = p1P2Control1;
            P1P2Control2 = p1P2Control2;
            P2 = p2;
            P2P3Control1 = p2P3Control1;
            P2P3Control2 = p2P3Control2;
            P3 = p3;
            P3P4Control1 = p3P4Control1;
            P3P4Control2 = p3P4Control2;
            P4 = p4;
            P4P1Control1 = p4P1Control1;
            P4P1Control2 = p4P1Control2;
        }

        protected override void AddNodes()
        {
            InternalNodes.Add(new IgesNode(File, P1));
            InternalNodes.Add(new IgesNode(File, P1P2Control1));
            InternalNodes.Add(new IgesNode(File, P1P2Control2));
            InternalNodes.Add(new IgesNode(File, P2));
            InternalNodes.Add(new IgesNode(File, P2P3Control1));
            InternalNodes.Add(new IgesNode(File, P2P3Control2));
            InternalNodes.Add(new IgesNode(File, P3));
            InternalNodes.Add(new IgesNode(File, P3P4Control1));
            InternalNodes.Add(new IgesNode(File, P3P4Control2));
            InternalNodes.Add(new IgesNode(File, P4));
            InternalNodes.Add(new IgesNode(File, P4P1Control1));
            InternalNodes.Add(new IgesNode(File, P4P1Control2));
        }

        internal static IgesCubicQuadrilateral FromDummy(IgesFiniteElementDummy dummy)
        {
            return new IgesCubicQuadrilateral(
                dummy.File,
                GetNodeOffset(dummy, 0),
                GetNodeOffset(dummy, 1),
                GetNodeOffset(dummy, 2),
                GetNodeOffset(dummy, 3),
                GetNodeOffset(dummy, 4),
                GetNodeOffset(dummy, 5),
                GetNodeOffset(dummy, 6),
                GetNodeOffset(dummy, 7),
                GetNodeOffset(dummy, 8),
                GetNodeOffset(dummy, 9),
                GetNodeOffset(dummy, 10),
                GetNodeOffset(dummy, 11));
        }
    }
}
