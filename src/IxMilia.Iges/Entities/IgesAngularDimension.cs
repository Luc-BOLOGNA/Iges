﻿// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MathNet.Spatial.Euclidean;
using System.Collections.Generic;

namespace IxMilia.Iges.Entities
{
    public class IgesAngularDimension : IgesDimensionBase
    {
        public IgesAngularDimension(IgesFile file) : base(file)
        {
        }

        public override IgesEntityType EntityType { get { return IgesEntityType.AngularDimension; } }

        public IgesCopiousData FirstWitnessLine { get; set; }
        public IgesCopiousData SecondWitnessLine { get; set; }
        public Point2D Vertex { get; set; } = Point2D.Origin;
        public double LeaderArcRadius { get; set; }

        internal override int ReadParameters(List<string> parameters, IgesReaderBinder binder)
        {
            var index = 0;
            binder.BindEntity(Integer(parameters, ref index), generalNote => GeneralNote = generalNote as IgesGeneralNote);
            binder.BindEntity(Integer(parameters, ref index), witness => FirstWitnessLine = witness as IgesCopiousData);
            binder.BindEntity(Integer(parameters, ref index), witness => SecondWitnessLine = witness as IgesCopiousData);
            Vertex = IgesPoint.Point2D(parameters, ref index);
            LeaderArcRadius = Double(parameters, ref index);
            binder.BindEntity(Integer(parameters, ref index), leader => FirstLeader = leader as IgesLeader);
            binder.BindEntity(Integer(parameters, ref index), leader => SecondLeader = leader as IgesLeader);
            return index;
        }

        internal override IEnumerable<IgesEntity> GetReferencedEntities()
        {
            foreach (var referenced in base.GetReferencedEntities())
            {
                yield return referenced;
            }

            yield return FirstWitnessLine;
            yield return SecondWitnessLine;
        }

        internal override void WriteParameters(List<object> parameters, IgesWriterBinder binder)
        {
            parameters.Add(binder.GetEntityId(GeneralNote));
            parameters.Add(binder.GetEntityId(FirstWitnessLine));
            parameters.Add(binder.GetEntityId(SecondWitnessLine));
            parameters.Add(Vertex.X);
            parameters.Add(Vertex.Y);
            parameters.Add(LeaderArcRadius);
            parameters.Add(binder.GetEntityId(FirstLeader));
            parameters.Add(binder.GetEntityId(SecondLeader));
        }
    }
}
