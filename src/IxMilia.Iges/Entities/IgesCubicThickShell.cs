﻿// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MathNet.Spatial.Euclidean;

namespace IxMilia.Iges.Entities
{
    public class IgesCubicThickShell : IgesFiniteElement
    {
        public override IgesElementEdgeOrder EdgeOrder { get { return IgesElementEdgeOrder.Cubic; } }

        public Point3D P1 { get; set; }
        public Point3D P1P2Control1 { get; set; }
        public Point3D P1P2Control2 { get; set; }
        public Point3D P2 { get; set; }
        public Point3D P2P3Control1 { get; set; }
        public Point3D P2P3Control2 { get; set; }
        public Point3D P3 { get; set; }
        public Point3D P3P1Control1 { get; set; }
        public Point3D P3P4Control2 { get; set; }
        public Point3D P4 { get; set; }
        public Point3D P4P1Control1 { get; set; }
        public Point3D P4P1Control2 { get; set; }
        public Point3D P5 { get; set; }
        public Point3D P5P6Control1 { get; set; }
        public Point3D P5P6Control2 { get; set; }
        public Point3D P6 { get; set; }
        public Point3D P6P7Control1 { get; set; }
        public Point3D P6P7Control2 { get; set; }
        public Point3D P7 { get; set; }
        public Point3D P7P8Control1 { get; set; }
        public Point3D P7P8Control2 { get; set; }
        public Point3D P8 { get; set; }
        public Point3D P8P5Control1 { get; set; }
        public Point3D P8P5Control2 { get; set; }

        public IgesCubicThickShell(
            IgesFile file,
            Point3D p1,
            Point3D p1P2Control1,
            Point3D p1P2Control2,
            Point3D p2,
            Point3D p2P3Control1,
            Point3D p2P3Control2,
            Point3D p3,
            Point3D p3P1Control1,
            Point3D p3P4Control2,
            Point3D p4,
            Point3D p4P1Control1,
            Point3D p4P1Control2,
            Point3D p5,
            Point3D p5P6Control1,
            Point3D p5P6Control2,
            Point3D p6,
            Point3D p6P7Control1,
            Point3D p6P7Control2,
            Point3D p7,
            Point3D p7P8Control1,
            Point3D p7P8Control2,
            Point3D p8,
            Point3D p8P5Control1,
            Point3D p8P5Control2)
            : base(file, IgesTopologyType.CubicThickShell)
        {
            P1 = p1;
            P1P2Control1 = p1P2Control1;
            P1P2Control2 = p1P2Control2;
            P2 = p2;
            P2P3Control1 = p2P3Control1;
            P2P3Control2 = p2P3Control2;
            P3 = p3;
            P3P1Control1 = p3P1Control1;
            P3P4Control2 = p3P4Control2;
            P4 = p4;
            P4P1Control1 = p4P1Control1;
            P4P1Control2 = p4P1Control2;
            P5 = p5;
            P5P6Control1 = p5P6Control1;
            P5P6Control2 = p5P6Control2;
            P6 = p6;
            P6P7Control1 = p6P7Control1;
            P6P7Control2 = p6P7Control2;
            P7 = p7;
            P7P8Control1 = p7P8Control1;
            P7P8Control2 = p7P8Control2;
            P8 = p8;
            P8P5Control1 = p8P5Control1;
            P8P5Control2 = p8P5Control2;
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
            InternalNodes.Add(new IgesNode(File, P3P1Control1));
            InternalNodes.Add(new IgesNode(File, P3P4Control2));
            InternalNodes.Add(new IgesNode(File, P4));
            InternalNodes.Add(new IgesNode(File, P4P1Control1));
            InternalNodes.Add(new IgesNode(File, P4P1Control2));
            InternalNodes.Add(new IgesNode(File, P5));
            InternalNodes.Add(new IgesNode(File, P5P6Control1));
            InternalNodes.Add(new IgesNode(File, P5P6Control2));
            InternalNodes.Add(new IgesNode(File, P6));
            InternalNodes.Add(new IgesNode(File, P6P7Control1));
            InternalNodes.Add(new IgesNode(File, P6P7Control2));
            InternalNodes.Add(new IgesNode(File, P7));
            InternalNodes.Add(new IgesNode(File, P7P8Control1));
            InternalNodes.Add(new IgesNode(File, P7P8Control2));
            InternalNodes.Add(new IgesNode(File, P8));
            InternalNodes.Add(new IgesNode(File, P8P5Control1));
            InternalNodes.Add(new IgesNode(File, P8P5Control2));
        }

        internal static IgesCubicThickShell FromDummy(IgesFiniteElementDummy dummy)
        {
            return new IgesCubicThickShell(
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
                GetNodeOffset(dummy, 19),
                GetNodeOffset(dummy, 20),
                GetNodeOffset(dummy, 21),
                GetNodeOffset(dummy, 22),
                GetNodeOffset(dummy, 23));
        }
    }
}
