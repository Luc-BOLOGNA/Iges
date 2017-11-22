// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MathNet.Spatial.Euclidean;
using System;
using System.Collections.Generic;

namespace IxMilia.Iges.Entities
{
    [Flags]
    public enum IgesDepthClipping
    {
        None = 0x00,
        BackClipping = 0x01,
        FrontClipping = 0x02,
        FrontAndBackClipping = BackClipping | FrontClipping
    }

    public class IgesPerspectiveView : IgesViewBase
    {
        public IgesPerspectiveView(IgesFile file)
            : this(file, 0, 0.0, IgesVector.Zero, Point3D.Origin, Point3D.Origin, IgesVector.Zero, 0.0, 0.0, 0.0, 0.0, 0.0, IgesDepthClipping.None, 0.0, 0.0)
        {
        }

        public IgesPerspectiveView(
            IgesFile file,
            int viewNumber,
            double scaleFactor,
            Vector3D viewPlaneNormal,
            Point3D referencePoint,
            Point3D centerOfProjection,
            Vector3D upVector,
            double viewPlaneDistance,
            double leftClippingCoordinate,
            double rightClippingCoordinate,
            double bottomClippingCoordinate,
            double topClippingCoordinate,
            IgesDepthClipping depthClipping,
            double backClippingCoordinate,
            double frontClippingCoordinate)
            : base(file, viewNumber, scaleFactor)
        {
            this.FormNumber = 1;
            this.ViewPlaneNormal = viewPlaneNormal;
            this.ViewReferencePoint = referencePoint;
            this.CenterOfProjection = centerOfProjection;
            this.ViewUpVector = upVector;
            this.ViewPlaneDistance = viewPlaneDistance;
            this.ClippingWindowLeftCoordinate = leftClippingCoordinate;
            this.ClippingWindowRightCoordinate = rightClippingCoordinate;
            this.ClippingWindowBottomCoordinate = bottomClippingCoordinate;
            this.ClippingWindowTopCoordinate = topClippingCoordinate;
            this.DepthClipping = depthClipping;
            this.ClippingWindowBackCoordinate = backClippingCoordinate;
            this.ClippingWindowFrontCoordinate = frontClippingCoordinate;
        }

        public Vector3D ViewPlaneNormal { get; set; }
        public Point3D ViewReferencePoint { get; set; }
        public Point3D CenterOfProjection { get; set; }
        public Vector3D ViewUpVector { get; set; }
        public double ViewPlaneDistance { get; set; }
        public double ClippingWindowLeftCoordinate { get; set; }
        public double ClippingWindowRightCoordinate { get; set; }
        public double ClippingWindowBottomCoordinate { get; set; }
        public double ClippingWindowTopCoordinate { get; set; }
        public IgesDepthClipping DepthClipping { get; set; }
        public double ClippingWindowBackCoordinate { get; set; }
        public double ClippingWindowFrontCoordinate { get; set; }

        internal override int ReadParameters(List<string> parameters, IgesReaderBinder binder)
        {
            int nextIndex = base.ReadParameters(parameters, binder);
            this.ViewPlaneNormal = IgesVector.Vector3D(parameters, ref nextIndex);
            this.ViewReferencePoint = IgesPoint.Point3D(parameters, ref nextIndex);
            this.CenterOfProjection = IgesPoint.Point3D(parameters, ref nextIndex);
            this.ViewUpVector = IgesVector.Vector3D(parameters, ref nextIndex);
            this.ViewPlaneDistance = Double(parameters, ref nextIndex);
            this.ClippingWindowLeftCoordinate = Double(parameters, ref nextIndex);
            this.ClippingWindowRightCoordinate = Double(parameters, ref nextIndex);
            this.ClippingWindowBottomCoordinate = Double(parameters, ref nextIndex);
            this.ClippingWindowTopCoordinate = Double(parameters, ref nextIndex);
            this.DepthClipping = (IgesDepthClipping)Integer(parameters, ref nextIndex);
            this.ClippingWindowBackCoordinate = Double(parameters, ref nextIndex);
            this.ClippingWindowFrontCoordinate = Double(parameters, ref nextIndex);
            return nextIndex;
        }

        internal override void WriteParameters(List<object> parameters, IgesWriterBinder binder)
        {
            base.WriteParameters(parameters, binder);
            parameters.Add(ViewPlaneNormal.X);
            parameters.Add(ViewPlaneNormal.Y);
            parameters.Add(ViewPlaneNormal.Z);
            parameters.Add(ViewReferencePoint.X);
            parameters.Add(ViewReferencePoint.Y);
            parameters.Add(ViewReferencePoint.Z);
            parameters.Add(CenterOfProjection.X);
            parameters.Add(CenterOfProjection.Y);
            parameters.Add(CenterOfProjection.Z);
            parameters.Add(ViewUpVector.X);
            parameters.Add(ViewUpVector.Y);
            parameters.Add(ViewUpVector.Z);
            parameters.Add(ViewPlaneDistance);
            parameters.Add(ClippingWindowLeftCoordinate);
            parameters.Add(ClippingWindowRightCoordinate);
            parameters.Add(ClippingWindowBottomCoordinate);
            parameters.Add(ClippingWindowTopCoordinate);
            parameters.Add((int)DepthClipping);
            parameters.Add(ClippingWindowBackCoordinate);
            parameters.Add(ClippingWindowFrontCoordinate);
        }
    }
}
