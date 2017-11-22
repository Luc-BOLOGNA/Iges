// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MathNet.Spatial.Euclidean;

namespace IxMilia.Iges.Entities
{
    public class IgesAxisymmetricParabolicLine : IgesFiniteElement
    {
        public override IgesElementEdgeOrder EdgeOrder { get { return IgesElementEdgeOrder.Parabolic; } }

        public Point3D P1 { get; set; }
        public Point3D P2 { get; set; }
        public Point3D P3 { get; set; }

        public IgesAxisymmetricParabolicLine(
            IgesFile file,
            Point3D p1,
            Point3D p2,
            Point3D p3)
            : base(file, IgesTopologyType.AxisymmetricParabolicLine)
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
        }

        protected override void AddNodes()
        {
            InternalNodes.Add(new IgesNode(File, P1));
            InternalNodes.Add(new IgesNode(File, P2));
            InternalNodes.Add(new IgesNode(File, P3));
        }

        internal static IgesAxisymmetricParabolicLine FromDummy(IgesFiniteElementDummy dummy)
        {
            return new IgesAxisymmetricParabolicLine(
                dummy.File,
                GetNodeOffset(dummy, 0),
                GetNodeOffset(dummy, 1),
                GetNodeOffset(dummy, 2));
        }
    }
}
