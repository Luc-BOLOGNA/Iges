// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using IxMilia.Iges.Collections;

namespace IxMilia.Iges.Entities
{
    public enum IgesGeneralSymbolType
    {
        General = 0,
        DatumFeature = 1,
        DatumTarget = 2,
        FeatureControl = 3,
    }

    public class IgesGeneralSymbol : IgesEntity
    {
        public override IgesEntityType EntityType { get { return IgesEntityType.GeneralSymbol; } }

        public IgesGeneralNote Note { get; set; }
        public IList<IgesLeader> Leaders { get; }
        public IList<IgesEntity> Geometries { get; }

        public IgesGeneralSymbolType SymbolType
        {
            get { return (IgesGeneralSymbolType)FormNumber; }
            set { FormNumber = (int)value; }
        }

        internal IgesGeneralSymbol(IgesFile file)
            :base(file)
        {
            EntityUseFlag = IgesEntityUseFlag.Annotation;
            Leaders = new ListNonNull<IgesLeader>();
            Geometries = new ListNonNullWithMinimum<IgesEntity>(1);
        }

        public IgesGeneralSymbol(IgesFile file, IgesGeneralNote note, IEnumerable<IgesLeader> leaders, IEnumerable<IgesEntity> geometries)
            : this(file)
        {
            Note = note;
            foreach (var leader in leaders)
            {
                Leaders.Add(leader);
            }

            foreach (var geometry in geometries)
            {
                Geometries.Add(geometry);
            }

            if (Geometries.Count < 1)
            {
                throw new InvalidOperationException($"At least one geometrical entity must be specified.");
            }
        }

        internal override int ReadParameters(List<string> parameters, IgesReaderBinder binder)
        {
            var index = 0;
            binder.BindEntity(Integer(parameters, ref index), e => Note = e as IgesGeneralNote);
            var geometryCount = Integer(parameters, ref index);
            for (int i = 0; i < geometryCount; i++)
            {
                binder.BindEntity(Integer(parameters, ref index), e => Geometries.Add(e));
            }

            var leaderCount = Integer(parameters, ref index);
            for (int i = 0; i < leaderCount; i++)
            {
                binder.BindEntity(Integer(parameters, ref index), e => Leaders.Add(e as IgesLeader));
            }

            return index;
        }

        internal override IEnumerable<IgesEntity> GetReferencedEntities()
        {
            yield return Note;
            foreach (var leader in Leaders)
            {
                yield return leader;
            }

            foreach (var geometry in Geometries)
            {
                yield return geometry;
            }
        }

        internal override void WriteParameters(List<object> parameters, IgesWriterBinder binder)
        {
            parameters.Add(binder.GetEntityId(Note));
            parameters.Add(Geometries.Count);
            foreach (var geometry in Geometries)
            {
                parameters.Add(binder.GetEntityId(geometry));
            }

            parameters.Add(Leaders.Count);
            foreach (var leader in Leaders)
            {
                parameters.Add(binder.GetEntityId(leader));
            }
        }
    }
}
