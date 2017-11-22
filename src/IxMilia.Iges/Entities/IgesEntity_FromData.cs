// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Generic;

namespace IxMilia.Iges.Entities
{
    public abstract partial class IgesEntity
    {
        public readonly IgesFile File;
        internal static IgesEntity FromData(IgesDirectoryData directoryData, List<string> parameters, IgesReaderBinder binder, IgesFile file)
        {
            IgesEntity entity = null;
            switch (directoryData.EntityType)
            {
                case IgesEntityType.AngularDimension:
                    entity = new IgesAngularDimension(file);
                    break;
                case IgesEntityType.AssociativityInstance:
                    switch (directoryData.FormNumber)
                    {
                        case 5:
                            entity = new IgesLabelDisplayAssociativity(file);
                            break;
                    }
                    break;
                case IgesEntityType.Block:
                    entity = new IgesBlock(file);
                    break;
                case IgesEntityType.BooleanTree:
                    entity = new IgesBooleanTree(file);
                    break;
                case IgesEntityType.Boundary:
                    entity = new IgesBoundary(file);
                    break;
                case IgesEntityType.BoundedSurface:
                    entity = new IgesBoundedSurface(file);
                    break;
                case IgesEntityType.CircularArc:
                    entity = new IgesCircularArc(file);
                    break;
                case IgesEntityType.ColorDefinition:
                    entity = new IgesColorDefinition(file);
                    break;
                case IgesEntityType.CompositeCurve:
                    entity = new IgesCompositeCurve(file);
                    break;
                case IgesEntityType.ConicArc:
                    entity = new IgesConicArc(file);
                    break;
                case IgesEntityType.ConnectPoint:
                    entity = new IgesConnectPoint(file);
                    break;
                case IgesEntityType.CopiousData:
                    entity = new IgesCopiousData(file);
                    break;
                case IgesEntityType.CurveDimension:
                    entity = new IgesCurveDimension(file);
                    break;
                case IgesEntityType.CurveOnAParametricSurface:
                    entity = new IgesCurveOnAParametricSurface(file);
                    break;
                case IgesEntityType.DiameterDimension:
                    entity = new IgesDiameterDimension(file);
                    break;
                case IgesEntityType.Direction:
                    entity = new IgesDirection(file);
                    break;
                case IgesEntityType.ElementResults:
                    entity = new IgesElementResults(file);
                    break;
                case IgesEntityType.Ellipsoid:
                    entity = new IgesEllipsoid(file);
                    break;
                case IgesEntityType.FlagNote:
                    entity = new IgesFlagNote(file);
                    break;
                case IgesEntityType.Flash:
                    entity = new IgesFlash(file);
                    break;
                case IgesEntityType.FiniteElement:
                    entity = new IgesFiniteElementDummy(file);
                    break;
                case IgesEntityType.GeneralLabel:
                    entity = new IgesGeneralLabel(file);
                    break;
                case IgesEntityType.GeneralNote:
                    entity = new IgesGeneralNote(file);
                    break;
                case IgesEntityType.GeneralSymbol:
                    entity = new IgesGeneralSymbol(file);
                    break;
                case IgesEntityType.Leader:
                    entity = new IgesLeader(file);
                    break;
                case IgesEntityType.Line:
                    entity = new IgesLine2D(file);
                    break;
                case IgesEntityType.LinearDimension:
                    entity = new IgesLinearDimension(file);
                    break;
                case IgesEntityType.LineFontDefinition:
                    switch (directoryData.FormNumber)
                    {
                        case 1:
                            entity = new IgesTemplateLineFontDefinition(file);
                            break;
                        case 2:
                            entity = new IgesPatternLineFontDefinition(file);
                            break;
                    }
                    break;
                case IgesEntityType.ManifestSolidBRepObject:
                    entity = new IgesManifestSolidBRepObject(file);
                    break;
                case IgesEntityType.NewGeneralNote:
                    entity = new IgesNewGeneralNote(file);
                    break;
                case IgesEntityType.NodalDisplacementAndRotation:
                    entity = new IgesNodalDisplacementAndRotation(file);
                    break;
                case IgesEntityType.NodalResults:
                    entity = new IgesNodalResults(file);
                    break;
                case IgesEntityType.Node:
                    entity = new IgesNode(file);
                    break;
                case IgesEntityType.Null:
                    entity = new IgesNull(file);
                    break;
                case IgesEntityType.OffsetCurve:
                    entity = new IgesOffsetCurve(file);
                    break;
                case IgesEntityType.OffsetSurface:
                    entity = new IgesOffsetSurface(file);
                    break;
                case IgesEntityType.OrdinateDimension:
                    entity = new IgesOrdinateDimension(file);
                    break;
                case IgesEntityType.ParametricSplineCurve:
                    entity = new IgesParametricSplineCurve(file);
                    break;
                case IgesEntityType.ParametricSplineSurface:
                    entity = new IgesParametricSplineSurface(file);
                    break;
                case IgesEntityType.Plane:
                    entity = new IgesPlane(file);
                    break;
                case IgesEntityType.PlaneSurface:
                    entity = new IgesPlaneSurface(file);
                    break;
                case IgesEntityType.Point:
                    entity = new IgesLocation(file);
                    break;
                case IgesEntityType.PointDimension:
                    entity = new IgesPointDimension(file);
                    break;
                case IgesEntityType.Property:
                    switch (directoryData.FormNumber)
                    {
                        case 1:
                            entity = new IgesDefinitionLevelsProperty(file);
                            break;
                    }
                    break;
                case IgesEntityType.RadiusDimension:
                    entity = new IgesRadiusDimension(file);
                    break;
                case IgesEntityType.RationalBSplineCurve:
                    entity = new IgesRationalBSplineCurve(file);
                    break;
                case IgesEntityType.RationalBSplineSurface:
                    entity = new IgesRationalBSplineSurface(file);
                    break;
                case IgesEntityType.RightAngularWedge:
                    entity = new IgesRightAngularWedge(file);
                    break;
                case IgesEntityType.RightCircularConeFrustrum:
                    entity = new IgesRightCircularConeFrustrum(file);
                    break;
                case IgesEntityType.RightCircularConicalSurface:
                    entity = new IgesRightCircularConicalSurface(file);
                    break;
                case IgesEntityType.RightCircularCylinder:
                    entity = new IgesRightCircularCylinder(file);
                    break;
                case IgesEntityType.RightCircularCylindricalSurface:
                    entity = new IgesRightCircularCylindricalSurface(file);
                    break;
                case IgesEntityType.RuledSurface:
                    entity = new IgesRuledSurface(file);
                    break;
                case IgesEntityType.SelectedComponent:
                    entity = new IgesSelectedComponent(file);
                    break;
                case IgesEntityType.SolidAssembly:
                    entity = new IgesSolidAssembly(file);
                    break;
                case IgesEntityType.SolidOfLinearExtrusion:
                    entity = new IgesSolidOfLinearExtrusion(file);
                    break;
                case IgesEntityType.SolidOfRevolution:
                    entity = new IgesSolidOfRevolution(file);
                    break;
                case IgesEntityType.Sphere:
                    entity = new IgesSphere(file);
                    break;
                case IgesEntityType.SphericalSurface:
                    entity = new IgesSphericalSurface(file);
                    break;
                case IgesEntityType.SubfigureDefinition:
                    entity = new IgesSubfigureDefinition(file);
                    break;
                case IgesEntityType.SurfaceOfRevolution:
                    entity = new IgesSurfaceOfRevolution(file);
                    break;
                case IgesEntityType.TabulatedCylinder:
                    entity = new IgesTabulatedCylinder(file);
                    break;
                case IgesEntityType.TextDisplayTemplate:
                    entity = new IgesTextDisplayTemplate(file);
                    break;
                case IgesEntityType.TextFontDefinition:
                    entity = new IgesTextFontDefinition(file);
                    break;
                case IgesEntityType.ToroidalSurface:
                    entity = new IgesToroidalSurface(file);
                    break;
                case IgesEntityType.Torus:
                    entity = new IgesTorus(file);
                    break;
                case IgesEntityType.TransformationMatrix:
                    entity = new IgesTransformationMatrix(file);
                    break;
                case IgesEntityType.TrimmedParametricSurface:
                    entity = new IgesTrimmedParametricSurface(file);
                    break;
                case IgesEntityType.View:
                    switch (directoryData.FormNumber)
                    {
                        case 0:
                            entity = new IgesView(file);
                            break;
                        case 1:
                            entity = new IgesPerspectiveView(file);
                            break;
                    }
                    break;
            }

            if (entity != null)
            {
                entity.PopulateDirectoryData(directoryData);
                int nextIndex = entity.ReadParameters(parameters, binder);
                entity.ReadCommonPointers(parameters, nextIndex, binder);
            }

            return entity;
        }
    }
}
