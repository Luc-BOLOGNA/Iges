// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MathNet.Spatial.Euclidean;
using System.Collections.Generic;

namespace IxMilia.Iges.Entities
{
    public class IgesDiameterDimension : IgesDimensionBase
    {
        public IgesDiameterDimension(IgesFile file)
            : base(file)
        {
        }

        public override IgesEntityType EntityType { get { return IgesEntityType.DiameterDimension; } }

        public Point2D ArcCenter { get; set; } = Point2D.Origin;

        internal override int ReadParameters(List<string> parameters, IgesReaderBinder binder)
        {
            var index = 0;
            binder.BindEntity(Integer(parameters, ref index), generalNote => GeneralNote = generalNote as IgesGeneralNote);
            binder.BindEntity(Integer(parameters, ref index), leader => FirstLeader = leader as IgesLeader);
            binder.BindEntity(Integer(parameters, ref index), leader => SecondLeader = leader as IgesLeader);
            ArcCenter = IgesPoint.Point2D(parameters, ref index);
            return index;
        }

        internal override void WriteParameters(List<object> parameters, IgesWriterBinder binder)
        {
            parameters.Add(binder.GetEntityId(GeneralNote));
            parameters.Add(binder.GetEntityId(FirstLeader));
            parameters.Add(binder.GetEntityId(SecondLeader));
            parameters.Add(ArcCenter.X);
            parameters.Add(ArcCenter.Y);
        }
    }
}
