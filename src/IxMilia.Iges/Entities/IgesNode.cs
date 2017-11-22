// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MathNet.Spatial.Euclidean;
using System.Collections.Generic;

namespace IxMilia.Iges.Entities
{
    public class IgesNode : IgesEntity
    {
        public override IgesEntityType EntityType { get { return IgesEntityType.Node; } }

        public Point3D Offset { get; set; }

        public IgesTransformationMatrix DisplacementCoordinateSystem { get; set; }

        public uint NodeNumber
        {
            get { return EntitySubscript; }
            set { EntitySubscript = value; }
        }

        public IgesNode(IgesFile file)
            : this(file, Point3D.Origin)
        {
        }

        public IgesNode(IgesFile file, Point3D offset)
            : base(file)
        {
            EntityUseFlag = IgesEntityUseFlag.LogicalOrPositional;
            FormNumber = 0;
            Offset = offset;
        }

        internal override int ReadParameters(List<string> parameters, IgesReaderBinder binder)
        {
            this.Offset = IgesPoint.Point3D(parameters, 0);
            binder.BindEntity(Integer(parameters, 3), e => DisplacementCoordinateSystem = e as IgesTransformationMatrix);
            return 4;
        }

        internal override IEnumerable<IgesEntity> GetReferencedEntities()
        {
            yield return DisplacementCoordinateSystem;
        }

        internal override void WriteParameters(List<object> parameters, IgesWriterBinder binder)
        {
            parameters.Add(this.Offset.X);
            parameters.Add(this.Offset.Y);
            parameters.Add(this.Offset.Z);
            parameters.Add(binder.GetEntityId(DisplacementCoordinateSystem));
        }
    }
}
