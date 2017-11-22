// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using IxMilia.Iges.Entities;
using MathNet.Spatial.Euclidean;
using System;
using System.Collections.Generic;

namespace IxMilia.Iges
{
    public static class IgesPoint
    {
        public static Point2D ToPoint2D(this Point3D point) => new Point2D(point.X, point.Y);

        public static string ToString(this Point3D point)
        {
            return string.Format("({0},{1},{2})", point.X, point.Y, point.Z);
        }

        public static string ToString(this Point2D point)
        {
            return string.Format("({0},{1})", point.X, point.Y);
        }

        internal static Point2D Point2D(List<string> parameters, int index)
        {
            int i = index;
            return Point2D(parameters, ref i);

        }

        internal static Point2D Point2D(List<string> parameters, ref int index)
        {
            return new Point2D(
                IgesParameterReader.Double(parameters, index++),
                IgesParameterReader.Double(parameters, index++));
        }

        internal static Point3D Point3D(List<string> parameters, int index)
        {
            int i = index;
            return Point3D(parameters, ref i);
        }

        internal static Point3D Point3D(List<string> parameters, ref int index)
        {
            return new Point3D(
                IgesParameterReader.Double(parameters, index++),
                IgesParameterReader.Double(parameters, index++),
                IgesParameterReader.Double(parameters, index++));
        }

        internal static void WriteParameters(this Point2D point, List<object> parameters, IgesWriterBinder binder)
        {
            parameters.Add(point.X);
            parameters.Add(point.Y);
        }

        internal static void WriteParameters(this Point3D point, List<object> parameters, IgesWriterBinder binder)
        {
            parameters.Add(point.X);
            parameters.Add(point.Y);
            parameters.Add(point.Z);
        }
    }

    public static class IgesVector
    {
        internal static Vector3D Vector3D(List<string> parameters, int index)
        {
            int i = index;
            return Vector3D(parameters, ref i);
        }
        internal static Vector3D Vector3D(List<string> parameters, ref int index)
        {
            return new Vector3D(
                IgesEntity.Double(parameters, ref index),
                IgesEntity.Double(parameters, ref index),
                IgesEntity.Double(parameters, ref index));
        }

        internal static Vector3D ReadXAxis(List<string> parameters, ref int index)
        {
            return new Vector3D(
                IgesEntity.Double(parameters, ref index, 1.0),
                IgesEntity.Double(parameters, ref index),
                IgesEntity.Double(parameters, ref index));
        }

        internal static Vector3D ReadYAxis(List<string> parameters, ref int index)
        {
            return new Vector3D(
                IgesEntity.Double(parameters, ref index),
                IgesEntity.Double(parameters, ref index, 1.0),
                IgesEntity.Double(parameters, ref index));
        }

        internal static Vector3D ReadZAxis(List<string> parameters, int index)
        {
            int i = index;
            return ReadXAxis(parameters, ref i);
        }
        internal static Vector3D ReadZAxis(List<string> parameters, ref int index)
        {
            return new Vector3D(
                IgesEntity.Double(parameters, ref index),
                IgesEntity.Double(parameters, ref index),
                IgesEntity.Double(parameters, ref index, 1.0));
        }

        public static readonly Vector3D Zero = new Vector3D(0.0, 0.0, 0.0);
        public static readonly Vector3D XAxis = new Vector3D(1.0, 0.0, 0.0);
        public static readonly Vector3D YAxis = new Vector3D(0.0, 1.0, 0.0);
        public static readonly Vector3D ZAxis = new Vector3D(0.0, 0.0, 1.0);

        internal static void WriteParameters(this Vector3D vector, List<object> parameters, IgesWriterBinder binder)
        {
            parameters.Add(vector.X);
            parameters.Add(vector.Y);
            parameters.Add(vector.Z);
        }
    }
}
