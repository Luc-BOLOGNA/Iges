﻿// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Generic;

namespace IxMilia.Iges.Entities
{
    public class IgesCurveDimension : IgesDimensionBase
    {
        public IgesCurveDimension(IgesFile file) : base(file)
        {
        }

        public override IgesEntityType EntityType { get { return IgesEntityType.CurveDimension; } }

        public IgesEntity FirstCurve { get; set; }
        public IgesEntity SecondCurve { get; set; }
        public IgesCopiousData FirstWitnessLine { get; set; }
        public IgesCopiousData SecondWitnessLine { get; set; }

        internal override int ReadParameters(List<string> parameters, IgesReaderBinder binder)
        {
            var index = 0;
            binder.BindEntity(Integer(parameters, ref index), generalNote => GeneralNote = generalNote as IgesGeneralNote);
            binder.BindEntity(Integer(parameters, ref index), curve => FirstCurve = curve);
            binder.BindEntity(Integer(parameters, ref index), curve => SecondCurve = curve);
            binder.BindEntity(Integer(parameters, ref index), leader => FirstLeader = leader as IgesLeader);
            binder.BindEntity(Integer(parameters, ref index), leader => SecondLeader = leader as IgesLeader);
            binder.BindEntity(Integer(parameters, ref index), witness => FirstWitnessLine = witness as IgesCopiousData);
            binder.BindEntity(Integer(parameters, ref index), witness => SecondWitnessLine = witness as IgesCopiousData);
            return index;
        }

        internal override IEnumerable<IgesEntity> GetReferencedEntities()
        {
            foreach (var referenced in base.GetReferencedEntities())
            {
                yield return referenced;
            }

            yield return FirstCurve;
            yield return SecondCurve;
            yield return FirstWitnessLine;
            yield return SecondWitnessLine;
        }

        internal override void WriteParameters(List<object> parameters, IgesWriterBinder binder)
        {
            parameters.Add(binder.GetEntityId(GeneralNote));
            parameters.Add(binder.GetEntityId(FirstCurve));
            parameters.Add(binder.GetEntityId(SecondCurve));
            parameters.Add(binder.GetEntityId(FirstLeader));
            parameters.Add(binder.GetEntityId(SecondLeader));
            parameters.Add(binder.GetEntityId(FirstWitnessLine));
            parameters.Add(binder.GetEntityId(SecondWitnessLine));
        }
    }
}
