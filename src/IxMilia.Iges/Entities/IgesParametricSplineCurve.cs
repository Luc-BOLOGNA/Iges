// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Generic;

namespace IxMilia.Iges.Entities
{
    public enum IgesSplineType
    {
        Linear = 1,
        Quadratic = 2,
        Cubic = 3,
        WilsonFowler = 4,
        ModifiedWilsonFowler = 5,
        BSpline = 6
    }

    public class IgesSplinePolynomialSegment
    {
        public double BreakPoint { get; set; }
        public double AX { get; set; }
        public double BX { get; set; }
        public double CX { get; set; }
        public double DX { get; set; }
        public double AY { get; set; }
        public double BY { get; set; }
        public double CY { get; set; }
        public double DY { get; set; }
        public double AZ { get; set; }
        public double BZ { get; set; }
        public double CZ { get; set; }
        public double DZ { get; set; }
        public double XValue { get; set; }
        public double XFirstDerivative { get; set; }
        public double XSecondDerivative { get; set; }
        public double XThirdDerivative { get; set; }
        public double YValue { get; set; }
        public double YFirstDerivative { get; set; }
        public double YSecondDerivative { get; set; }
        public double YThirdDerivative { get; set; }
        public double ZValue { get; set; }
        public double ZFirstDerivative { get; set; }
        public double ZSecondDerivative { get; set; }
        public double ZThirdDerivative { get; set; }
    }

    public class IgesParametricSplineCurve : IgesEntity
    {
        public override IgesEntityType EntityType { get { return IgesEntityType.ParametricSplineCurve; } }

        public IgesSplineType SplineType { get; set; }
        public int DegreeOfContinuity { get; set; }
        public int NumberOfDimensions { get; set; }

        public List<IgesSplinePolynomialSegment> Segments { get; private set; }

        public IgesParametricSplineCurve(IgesFile file)
            : base(file)
        {
            SplineType = IgesSplineType.Linear;
            Segments = new List<IgesSplinePolynomialSegment>();
        }

        internal override int ReadParameters(List<string> parameters, IgesReaderBinder binder)
        {
            int index = 0;
            this.SplineType = (IgesSplineType)Integer(parameters, ref index);
            this.DegreeOfContinuity = Integer(parameters, ref index);
            this.NumberOfDimensions = Integer(parameters, ref index);
            var segmentCount = Integer(parameters, ref index);
            for (int i = 0; i < segmentCount; i++)
            {
                var breakPoint = Double(parameters, ref index);
                Segments.Add(new IgesSplinePolynomialSegment() { BreakPoint = breakPoint });
            }

            for (int i = 0; i < segmentCount; i++)
            {
                Segments[i].AX = Double(parameters, ref index);
                Segments[i].BX = Double(parameters, ref index);
                Segments[i].CX = Double(parameters, ref index);
                Segments[i].DX = Double(parameters, ref index);
                Segments[i].AY = Double(parameters, ref index);
                Segments[i].BY = Double(parameters, ref index);
                Segments[i].CY = Double(parameters, ref index);
                Segments[i].DY = Double(parameters, ref index);
                Segments[i].AZ = Double(parameters, ref index);
                Segments[i].BZ = Double(parameters, ref index);
                Segments[i].CZ = Double(parameters, ref index);
                Segments[i].DZ = Double(parameters, ref index);
            }

            for (int i = 0; i < segmentCount; i++)
            {
                Segments[i].XValue = Double(parameters, ref index);
                Segments[i].XFirstDerivative = Double(parameters, ref index);
                Segments[i].XSecondDerivative = Double(parameters, ref index);
                Segments[i].XThirdDerivative = Double(parameters, ref index);
                Segments[i].YValue = Double(parameters, ref index);
                Segments[i].YFirstDerivative = Double(parameters, ref index);
                Segments[i].YSecondDerivative = Double(parameters, ref index);
                Segments[i].YThirdDerivative = Double(parameters, ref index);
                Segments[i].ZValue = Double(parameters, ref index);
                Segments[i].ZFirstDerivative = Double(parameters, ref index);
                Segments[i].ZSecondDerivative = Double(parameters, ref index);
                Segments[i].ZThirdDerivative = Double(parameters, ref index);
            }

            return index;
        }

        internal override void WriteParameters(List<object> parameters, IgesWriterBinder binder)
        {
            parameters.Add((int)SplineType);
            parameters.Add(DegreeOfContinuity);
            parameters.Add(NumberOfDimensions);
            parameters.Add(Segments.Count);
            for (int i = 0; i < Segments.Count; i++)
            {
                parameters.Add(Segments[i].BreakPoint);
            }

            for (int i = 0; i < Segments.Count; i++)
            {
                parameters.Add(Segments[i].AX);
                parameters.Add(Segments[i].BX);
                parameters.Add(Segments[i].CX);
                parameters.Add(Segments[i].DX);
                parameters.Add(Segments[i].AY);
                parameters.Add(Segments[i].BY);
                parameters.Add(Segments[i].CY);
                parameters.Add(Segments[i].DY);
                parameters.Add(Segments[i].AZ);
                parameters.Add(Segments[i].BZ);
                parameters.Add(Segments[i].CZ);
                parameters.Add(Segments[i].DZ);
            }

            for (int i = 0; i < Segments.Count; i++)
            {
                parameters.Add(Segments[i].XValue);
                parameters.Add(Segments[i].XFirstDerivative);
                parameters.Add(Segments[i].XSecondDerivative);
                parameters.Add(Segments[i].XThirdDerivative);
                parameters.Add(Segments[i].YValue);
                parameters.Add(Segments[i].YFirstDerivative);
                parameters.Add(Segments[i].YSecondDerivative);
                parameters.Add(Segments[i].YThirdDerivative);
                parameters.Add(Segments[i].ZValue);
                parameters.Add(Segments[i].ZFirstDerivative);
                parameters.Add(Segments[i].ZSecondDerivative);
                parameters.Add(Segments[i].ZThirdDerivative);
            }
        }
    }
}
