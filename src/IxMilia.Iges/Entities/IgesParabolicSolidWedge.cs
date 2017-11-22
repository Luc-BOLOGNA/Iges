// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MathNet.Spatial.Euclidean;

namespace IxMilia.Iges.Entities
{
    public class IgesParabolicSolidWedge : IgesFiniteElement
    {
        public override IgesElementEdgeOrder EdgeOrder { get { return IgesElementEdgeOrder.Parabolic; } }

        public Point3D P1 { get; set; }
        public Point3D P1P2Control { get; set; }
        public Point3D P2 { get; set; }
        public Point3D P2P3Control { get; set; }
        public Point3D P3 { get; set; }
        public Point3D P3P1Control { get; set; }
        public Point3D P4P1Control { get; set; }
        public Point3D P5P2Control { get; set; }
        public Point3D P6P3Control { get; set; }
        public Point3D P4 { get; set; }
        public Point3D P4P5Control { get; set; }
        public Point3D P5 { get; set; }
        public Point3D P5P6Contro { get; set; }
        public Point3D P6 { get; set; }
        public Point3D P6P4Control { get; set; }

        public IgesParabolicSolidWedge(
            IgesFile file,
            Point3D p1,
            Point3D p1P2Control,
            Point3D p2,
            Point3D p2P3Control,
            Point3D p3,
            Point3D p3P1Control,
            Point3D p4P1Control,
            Point3D p5P2Control,
            Point3D p6P3Control,
            Point3D p4,
            Point3D p4P5Control,
            Point3D p5,
            Point3D p5P6Contro,
            Point3D p6,
            Point3D p6P4Control)
            : base(file, IgesTopologyType.ParabolicSolidWedge)
        {
            P1 = p1;
            P1P2Control = p1P2Control;
            P2 = p2;
            P2P3Control = p2P3Control;
            P3 = p3;
            P3P1Control = p3P1Control;
            P4P1Control = p4P1Control;
            P5P2Control = p5P2Control;
            P6P3Control = p6P3Control;
            P4 = p4;
            P4P5Control = p4P5Control;
            P5 = p5;
            P5P6Contro = p5P6Contro;
            P6 = p6;
            P6P4Control = p6P4Control;
        }

        protected override void AddNodes()
        {
            InternalNodes.Add(new IgesNode(File, P1));
            InternalNodes.Add(new IgesNode(File, P1P2Control));
            InternalNodes.Add(new IgesNode(File, P2));
            InternalNodes.Add(new IgesNode(File, P2P3Control));
            InternalNodes.Add(new IgesNode(File, P3));
            InternalNodes.Add(new IgesNode(File, P3P1Control));
            InternalNodes.Add(new IgesNode(File, P4P1Control));
            InternalNodes.Add(new IgesNode(File, P5P2Control));
            InternalNodes.Add(new IgesNode(File, P6P3Control));
            InternalNodes.Add(new IgesNode(File, P4));
            InternalNodes.Add(new IgesNode(File, P4P5Control));
            InternalNodes.Add(new IgesNode(File, P5));
            InternalNodes.Add(new IgesNode(File, P5P6Contro));
            InternalNodes.Add(new IgesNode(File, P6));
            InternalNodes.Add(new IgesNode(File, P6P4Control));
        }

        internal static IgesParabolicSolidWedge FromDummy(IgesFiniteElementDummy dummy)
        {
            return new IgesParabolicSolidWedge(
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
                GetNodeOffset(dummy, 11),
                GetNodeOffset(dummy, 12),
                GetNodeOffset(dummy, 13),
                GetNodeOffset(dummy, 14));
        }
    }
}
