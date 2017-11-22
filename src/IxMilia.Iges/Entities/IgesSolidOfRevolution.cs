// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MathNet.Spatial.Euclidean;
using System.Collections.Generic;

namespace IxMilia.Iges.Entities
{
    public class IgesSolidOfRevolution : IgesEntity
    {
        public override IgesEntityType EntityType { get { return IgesEntityType.SolidOfRevolution; } }

        public IgesEntity Curve { get; set; }
        public double RevolutionAmount { get; set; }
        public Point3D PointOnAxis { get; set; }
        public Vector3D AxisDirection { get; set; }

        public bool IsClosedToAxis
        {
            get { return FormNumber == 0; }
            set { FormNumber = value ? 0 : 1; }
        }

        public bool IsClosedToSelf
        {
            get { return FormNumber == 1; }
            set { FormNumber = value ? 1 : 0; }
        }

        public IgesSolidOfRevolution(IgesFile file)
            : base(file)

        {
            RevolutionAmount = 1.0;
            PointOnAxis = Point3D.Origin;
            AxisDirection = IgesVector.ZAxis;
        }

        internal override int ReadParameters(List<string> parameters, IgesReaderBinder binder)
        {
            binder.BindEntity(Integer(parameters, 0), e => Curve = e);
            RevolutionAmount = Double(parameters, 1);
            PointOnAxis = IgesPoint.Point3D(parameters, 2);
            AxisDirection = IgesVector.Vector3D(parameters, 5);
            return 8;
        }

        internal override IEnumerable<IgesEntity> GetReferencedEntities()
        {
            yield return Curve;
        }

        internal override void WriteParameters(List<object> parameters, IgesWriterBinder binder)
        {
            parameters.Add(binder.GetEntityId(Curve));
            parameters.Add(RevolutionAmount);
            parameters.Add(PointOnAxis.X);
            parameters.Add(PointOnAxis.Y);
            parameters.Add(PointOnAxis.Z);
            parameters.Add(AxisDirection.X);
            parameters.Add(AxisDirection.Y);
            parameters.Add(AxisDirection.Z);
        }
    }
}
