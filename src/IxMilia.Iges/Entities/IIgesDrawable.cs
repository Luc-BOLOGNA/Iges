using MathNet.Spatial.Euclidean;
using System;
using System.Collections.Generic;
using System.Text;

namespace IxMilia.Iges.Entities
{
    public interface IIgesDrawable2D
    {
        IgesEntityType EntityType { get; }

        Point2D StartPoint { get; }
        Point2D EndPoint { get; }

        IIgesDrawable2D Reverse();
    }

    public interface IIgesDrawable3D
    {
        IgesEntityType EntityType { get; }

        Point3D StartPoint { get; }
        Point3D EndPoint { get; }

        IIgesDrawable3D Reverse();
    }

}
