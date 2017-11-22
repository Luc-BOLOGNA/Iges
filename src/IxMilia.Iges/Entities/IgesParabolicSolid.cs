// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MathNet.Spatial.Euclidean;

namespace IxMilia.Iges.Entities
{
    public class IgesParabolicSolid : IgesFiniteElement
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
        public Point3D P5P1Control { get; set; }
        public Point3D P6P2Control { get; set; }
        public Point3D P7P3Control { get; set; }
        public Point3D P8P4Control { get; set; }
        public Point3D P5 { get; set; }
        public Point3D P5P6Control { get; set; }
        public Point3D P6 { get; set; }
        public Point3D P6P7Control { get; set; }
        public Point3D P7 { get; set; }
        public Point3D P7P8Control { get; set; }
        public Point3D P8 { get; set; }
        public Point3D P8P5Control { get; set; }

        public IgesParabolicSolid(
            IgesFile file,
            Point3D p1,
            Point3D p1P2Control,
            Point3D p2,
            Point3D p2P3Control,
            Point3D p3,
            Point3D p3P4Control,
            Point3D p4,
            Point3D p4P1Control,
            Point3D p5P1Control,
            Point3D p6P2Control,
            Point3D p7P3Control,
            Point3D p8P4Control,
            Point3D p5,
            Point3D p5P6Control,
            Point3D p6,
            Point3D p6P7Control,
            Point3D p7,
            Point3D p7P8Control,
            Point3D p8,
            Point3D p8P5Control)
            : base(file, IgesTopologyType.ParabolicSolid)
        {
            P1 = p1;
            P1P2Control = p1P2Control;
            P2 = p2;
            P2P3Control = p2P3Control;
            P3 = p3;
            P3P4Control = p3P4Control;
            P4 = p4;
            P4P1Control = p4P1Control;
            P5P1Control = p5P1Control;
            P6P2Control = p6P2Control;
            P7P3Control = p7P3Control;
            P8P4Control = p8P4Control;
            P5 = p5;
            P5P6Control = p5P6Control;
            P6 = p6;
            P6P7Control = p6P7Control;
            P7 = p7;
            P7P8Control = p7P8Control;
            P8 = p8;
            P8P5Control = p8P5Control;
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
            InternalNodes.Add(new IgesNode(File, P5P1Control));
            InternalNodes.Add(new IgesNode(File, P6P2Control));
            InternalNodes.Add(new IgesNode(File, P7P3Control));
            InternalNodes.Add(new IgesNode(File, P8P4Control));
            InternalNodes.Add(new IgesNode(File, P5));
            InternalNodes.Add(new IgesNode(File, P5P6Control));
            InternalNodes.Add(new IgesNode(File, P6));
            InternalNodes.Add(new IgesNode(File, P6P7Control));
            InternalNodes.Add(new IgesNode(File, P7));
            InternalNodes.Add(new IgesNode(File, P7P8Control));
            InternalNodes.Add(new IgesNode(File, P8));
            InternalNodes.Add(new IgesNode(File, P8P5Control));
        }

        internal static IgesParabolicSolid FromDummy(IgesFiniteElementDummy dummy)
        {
            return new IgesParabolicSolid(
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
                GetNodeOffset(dummy, 14),
                GetNodeOffset(dummy, 15),
                GetNodeOffset(dummy, 16),
                GetNodeOffset(dummy, 17),
                GetNodeOffset(dummy, 18),
                GetNodeOffset(dummy, 19));
        }
    }
}
