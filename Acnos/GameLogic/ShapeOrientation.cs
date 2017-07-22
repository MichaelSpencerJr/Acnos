using Acnos.GameLogic.Enums;
using System;

namespace Acnos.GameLogic
{
    /// <summary>
    /// Pair of immutable shape and orientation values.  To alter orientation a new
    /// ShapeOrientation object must be generated, to support ShapeOrientationCollection's
    /// modification-detection behavior.
    /// </summary>
    public struct ShapeOrientation : IEquatable<ShapeOrientation>, IComparable<ShapeOrientation>
    {
        public Shape Shape { get; private set; }
        public Orientation Orientation { get; private set; }

        public ShapeOrientation(Shape shape, Orientation orientation)
        {
            Shape = shape;
            Orientation = orientation;
        }

        /// <summary>
        /// Helper method for generating a new ShapeOrientation using
        /// the existing shape but a new orientation
        /// </summary>
        /// <param name="newOrientation"></param>
        /// <returns></returns>
        public ShapeOrientation ToOrientation(Orientation newOrientation)
        {
            return new ShapeOrientation(Shape, newOrientation);
        }

        public int CompareTo(ShapeOrientation other)
        {
            var retval = Shape.CompareTo(other.Shape);
            if (retval == 0)
                return Orientation.CompareTo(other.Orientation);
            return retval;
        }

        public bool Equals(ShapeOrientation other)
        {
            return Shape == other.Shape && Orientation == other.Orientation;
        }
    }
}
