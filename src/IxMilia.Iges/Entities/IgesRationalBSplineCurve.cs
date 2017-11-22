// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MathNet.Spatial.Euclidean;
using System.Collections.Generic;
using System.Diagnostics;

namespace IxMilia.Iges.Entities
{
    public enum IgesSplineCurveType
    {
        Custom = 0,
        Line = 1,
        CircularArc = 2,
        EllipticalArc = 3,
        ParabolicArc = 4,
        HyperbolicArc = 5
    }

    public class IgesRationalBSplineCurve : IgesEntity
    {
        public override IgesEntityType EntityType { get { return IgesEntityType.RationalBSplineCurve; } }

        public bool IsPlanar { get; set; }
        public bool IsClosed { get; set; }
        public bool IsPolynomial { get; set; }
        public bool IsPeriodic { get; set; }
        public List<double> KnotValues { get; private set; }
        public List<double> Weights { get; private set; }
        public List<Point3D> ControlPoints { get; private set; }
        public double StartParameter { get; set; }
        public double EndParameter { get; set; }
        public Vector3D Normal { get; set; }

        public IgesSplineCurveType CurveType
        {
            get { return (IgesSplineCurveType)FormNumber; }
            set { FormNumber = (int)value; }
        }

        public IgesRationalBSplineCurve(IgesFile file)
            : base(file)
        {
            KnotValues = new List<double>();
            Weights = new List<double>();
            ControlPoints = new List<Point3D>();
        }

        internal override int ReadParameters(List<string> parameters, IgesReaderBinder binder)
        {
            int index = 0;
            var k = Integer(parameters, ref index); // upper index of sum
            var m = Integer(parameters, ref index); // degree of basis functions
            IsPlanar = Boolean(parameters, ref index);
            IsClosed = Boolean(parameters, ref index);
            IsPolynomial = Boolean(parameters, ref index);
            IsPeriodic = Boolean(parameters, ref index);
            var n = 1 + k - m;
            var a = n + 2 * m;
            for (int i = 0; i < a + 1; i++)
            {
                KnotValues.Add(Double(parameters, ref index));
            }

            for (int i = 0; i < k + 1; i++)
            {
                Weights.Add(Double(parameters, ref index));
            }

            for (int i = 0; i < k + 1; i++)
            {
                var x = Double(parameters, ref index);
                var y = Double(parameters, ref index);
                var z = Double(parameters, ref index);
                ControlPoints.Add(new Point3D(x, y, z));
            }

            StartParameter = Double(parameters, ref index);
            EndParameter = Double(parameters, ref index);
            Normal = IsPlanar
                ? new Vector3D(Double(parameters, ref index), Double(parameters, ref index), Double(parameters, ref index))
                : IgesVector.ZAxis;

            return index;
        }

        internal override void WriteParameters(List<object> parameters, IgesWriterBinder binder)
        {
            var k = ControlPoints.Count - 1;
            var a = KnotValues.Count - 1;
            var m = a - 1 - k;
            var n = 1 + k - m;

            Debug.Assert(ControlPoints.Count == Weights.Count);
            Debug.Assert(KnotValues.Count == a + 1);
            Debug.Assert(Weights.Count == k + 1);
            Debug.Assert(ControlPoints.Count == k + 1);

            parameters.Add(k);
            parameters.Add(m);
            parameters.Add(IsPlanar ? 1 : 0);
            parameters.Add(IsClosed ? 1 : 0);
            parameters.Add(IsPolynomial ? 1 : 0);
            parameters.Add(IsPeriodic ? 1 : 0);
            for (int i = 0; i < KnotValues.Count; i++)
            {
                parameters.Add(KnotValues[i]);
            }

            for (int i = 0; i < Weights.Count; i++)
            {
                parameters.Add(Weights[i]);
            }

            for (int i = 0; i < ControlPoints.Count; i++)
            {
                parameters.Add(ControlPoints[i].X);
                parameters.Add(ControlPoints[i].Y);
                parameters.Add(ControlPoints[i].Z);
            }

            parameters.Add(StartParameter);
            parameters.Add(EndParameter);
            if (IsPlanar)
            {
                parameters.Add(Normal.X);
                parameters.Add(Normal.Y);
                parameters.Add(Normal.Z);
            }
        }
    }
}
