// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MathNet.Spatial.Euclidean;

namespace IxMilia.Iges.Entities
{
    public class IgesLinearSolidWedge : IgesFiniteElement
    {
        public override IgesElementEdgeOrder EdgeOrder { get { return IgesElementEdgeOrder.Linear; } }

        public Point3D P1 { get; set; }
        public Point3D P2 { get; set; }
        public Point3D P3 { get; set; }
        public Point3D P4 { get; set; }
        public Point3D P5 { get; set; }
        public Point3D P6 { get; set; }

        public IgesLinearSolidWedge(
            IgesFile file,
            Point3D p1,
            Point3D p2,
            Point3D p3,
            Point3D p4,
            Point3D p5,
            Point3D p6)
            : base(file, IgesTopologyType.LinearSolidWedge)
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
            P4 = p4;
            P5 = p5;
            P6 = p6;
        }

        protected override void AddNodes()
        {
            InternalNodes.Add(new IgesNode(File, P1));
            InternalNodes.Add(new IgesNode(File, P2));
            InternalNodes.Add(new IgesNode(File, P3));
            InternalNodes.Add(new IgesNode(File, P4));
            InternalNodes.Add(new IgesNode(File, P5));
            InternalNodes.Add(new IgesNode(File, P6));
        }

        internal static IgesLinearSolidWedge FromDummy(IgesFiniteElementDummy dummy)
        {
            return new IgesLinearSolidWedge(
                dummy.File,
                GetNodeOffset(dummy, 0),
                GetNodeOffset(dummy, 1),
                GetNodeOffset(dummy, 2),
                GetNodeOffset(dummy, 3),
                GetNodeOffset(dummy, 4),
                GetNodeOffset(dummy, 5));
        }
    }
}
