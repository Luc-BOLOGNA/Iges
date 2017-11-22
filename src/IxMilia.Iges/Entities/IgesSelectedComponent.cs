// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MathNet.Spatial.Euclidean;
using System.Collections.Generic;

namespace IxMilia.Iges.Entities
{
    public class IgesSelectedComponent : IgesEntity
    {
        public override IgesEntityType EntityType { get { return IgesEntityType.SelectedComponent; } }

        public IgesBooleanTree BooleanTree { get; set; }
        public Point3D SelectionPoint { get; set; }

        public IgesSelectedComponent(IgesFile file)
            : this(file, null, Point3D.Origin)
        {
        }

        public IgesSelectedComponent(IgesFile file, IgesBooleanTree booleanTree, Point3D selectionPoint)
            : base(file)
        {
            EntityUseFlag = IgesEntityUseFlag.Other;
            BooleanTree = booleanTree;
            SelectionPoint = selectionPoint;
        }

        internal override int ReadParameters(List<string> parameters, IgesReaderBinder binder)
        {
            binder.BindEntity(Integer(parameters, 0), e => BooleanTree = e as IgesBooleanTree);
            SelectionPoint = IgesPoint.Point3D(parameters, 1);
            return 4;
        }

        internal override IEnumerable<IgesEntity> GetReferencedEntities()
        {
            yield return BooleanTree;
        }

        internal override void WriteParameters(List<object> parameters, IgesWriterBinder binder)
        {
            parameters.Add(binder.GetEntityId(BooleanTree));
            parameters.Add(SelectionPoint.X);
            parameters.Add(SelectionPoint.Y);
            parameters.Add(SelectionPoint.Z);
        }
    }
}
