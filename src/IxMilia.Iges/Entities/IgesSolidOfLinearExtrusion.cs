// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MathNet.Spatial.Euclidean;
using System.Collections.Generic;

namespace IxMilia.Iges.Entities
{
    public class IgesSolidOfLinearExtrusion : IgesEntity
    {
        public IgesSolidOfLinearExtrusion(IgesFile file)
            : base(file)
        {
        }

        public override IgesEntityType EntityType { get { return IgesEntityType.SolidOfLinearExtrusion; } }

        public IgesEntity Curve { get; set; }
        public double ExtrusionLength { get; set; }
        public Vector3D ExtrusionDirection { get; set; } = IgesVector.ZAxis;

        internal override int ReadParameters(List<string> parameters, IgesReaderBinder binder)
        {
            binder.BindEntity(Integer(parameters, 0), e => Curve = e);
            ExtrusionLength = Double(parameters, 1);
            ExtrusionDirection = IgesVector.Vector3D(parameters, 2);
            return 5;
        }

        internal override IEnumerable<IgesEntity> GetReferencedEntities()
        {
            yield return Curve;
        }

        internal override void WriteParameters(List<object> parameters, IgesWriterBinder binder)
        {
            parameters.Add(binder.GetEntityId(Curve));
            parameters.Add(ExtrusionLength);
            parameters.Add(ExtrusionDirection.X);
            parameters.Add(ExtrusionDirection.Y);
            parameters.Add(ExtrusionDirection.Z);
        }
    }
}
