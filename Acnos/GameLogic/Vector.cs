using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Acnos.GameLogic
{
    /// <summary>
    /// Set of horizontal and vertical square offsets
    /// </summary>
    public struct Vector : IComparable<Vector>, IEquatable<Vector>
    {
        //Relative vectors will assume the following unit values for up, down, left, and right
        private const sbyte ColumnLeft = -1;
        private const sbyte ColumnRight = 1;
        private const sbyte LayerUp = 1;
        private const sbyte LayerDown = -1;

        /// <summary>
        /// Column offset relative to current piece column
        /// </summary>
        public sbyte Horizontal { get; set; }

        /// <summary>
        /// Layer/Rank/Row offset relative to current piece layer
        /// </summary>
        public sbyte Vertical { get; set; }

        /// <summary>
        /// Creates a new Vector with the provided horizontal and vertical offsets
        /// </summary>
        /// <param name="horizontal">Horizontal offset</param>
        /// <param name="vertical">Vertical offset</param>
        public Vector(int horizontal, int vertical)
        {
#if DEBUG
            Debug.Assert(ColumnLeft != ColumnRight, "ColumnLeft and ColumnRight must be different");
            Debug.Assert(LayerUp != LayerDown, "LayerUp and LayerDown must be different");
            Debug.Assert(ColumnLeft == 1 || ColumnLeft == -1, "ColumnLeft must be a unit integer, 1 or -1");
            Debug.Assert(ColumnRight == 1 || ColumnRight == -1, "ColumnRight must be a unit integer, 1 or -1");
            Debug.Assert(LayerUp == 1 || LayerUp == -1, "LayerUp must be a unit integer, 1 or -1");
            Debug.Assert(LayerDown == 1 || LayerDown == -1, "LayerDown must be a unit integer, 1 or -1");
#endif
            if (horizontal < -127 || horizontal > 127)
                throw new ArgumentOutOfRangeException(nameof(horizontal), "Out of range -127 - 127");
            if (vertical < -127 || vertical > 127)
                throw new ArgumentOutOfRangeException(nameof(vertical), "Out of range -127 - 127");
            Horizontal = (sbyte)horizontal;
            Vertical = (sbyte)vertical;
        }

        public bool Equals(Vector other) => 
            Horizontal == other.Horizontal && Vertical == other.Vertical;

        public static Vector operator +(Vector left, Vector right)
        {
            return new Vector(left.Horizontal + right.Horizontal, left.Vertical + right.Vertical);
        }

        public static Vector operator -(Vector left, Vector right)
        {
            return new Vector(left.Horizontal - right.Horizontal, left.Vertical - right.Vertical);
        }

        public static readonly Vector Up = new Vector(0, LayerUp);
        public static readonly Vector Right = new Vector(ColumnRight, 0);
        public static readonly Vector Down = new Vector(0, LayerDown);
        public static readonly Vector Left = new Vector(ColumnLeft, 0);
        public static readonly Vector UpLeft = new Vector(ColumnLeft, LayerUp);
        public static readonly Vector UpRight = new Vector(ColumnRight, LayerUp);
        public static readonly Vector DownLeft = new Vector(ColumnLeft, LayerDown);
        public static readonly Vector DownRight = new Vector(ColumnRight, LayerDown);
        public static readonly Vector Zero = new Vector(0, 0);

        public override string ToString()
        {
            if (Equals(Up)) return "Up";
            if (Equals(Right)) return "Right";
            if (Equals(Down)) return "Down";
            if (Equals(Left)) return "Left";
            if (Equals(UpLeft)) return "UpLeft";
            if (Equals(UpRight)) return "UpRight";
            if (Equals(DownLeft)) return "DownLeft";
            if (Equals(DownRight)) return "DownRight";
            return $"({Horizontal}, {Vertical})";
        }

        /// <summary>
        /// Outputs a set of adjacent-square vectors (magnitude 1 or sqrt(2) only) 
        /// as a series of distinct digits.  Other vectors are ignored.  Duplicates
        /// are removed and the vectors are sorted clockwise from Vector.Up before output.
        /// </summary>
        /// <param name="inputs">Set of adjacent-square vectors</param>
        /// <returns>Series of digits representing which vectors were present in the input</returns>
        public static string DistinctVectorsToString(IEnumerable<Vector> inputs)
        {
            var inputList = new HashSet<Vector>(inputs);
            var sb = new StringBuilder();
            if (inputList.Contains(Vector.Up)) sb.Append('1');
            if (inputList.Contains(Vector.UpRight)) sb.Append('2');
            if (inputList.Contains(Vector.Right)) sb.Append('3');
            if (inputList.Contains(Vector.DownRight)) sb.Append('4');
            if (inputList.Contains(Vector.Down)) sb.Append('5');
            if (inputList.Contains(Vector.DownLeft)) sb.Append('6');
            if (inputList.Contains(Vector.Left)) sb.Append('7');
            if (inputList.Contains(Vector.UpLeft)) sb.Append('8');
            return sb.ToString();
        }

        /// <summary>
        /// Outputs a set of adjacent-square vectors (magnitude 1 or sqrt(2) only)
        /// as a series of digits, in the order they are presented.  Duplicates are
        /// preserved and the output is unsorted.
        /// </summary>
        /// <param name="inputs">Set of adjacent-square vectors</param>
        /// <returns>Series of digits representing each vector in the order it appears</returns>
        public static string OrderedVectorsToString(IEnumerable<Vector> inputs)
        {
            var sb = new StringBuilder();
            foreach (var input in inputs)
            {
                if (input.Equals(Vector.Up)) { sb.Append('1'); continue; }
                if (input.Equals(Vector.UpRight)) { sb.Append('2'); continue; }
                if (input.Equals(Vector.Right)) { sb.Append('3'); continue; }
                if (input.Equals(Vector.DownRight)) { sb.Append('4'); continue; }
                if (input.Equals(Vector.Down)) { sb.Append('5'); continue; }
                if (input.Equals(Vector.DownLeft)) { sb.Append('6'); continue; }
                if (input.Equals(Vector.Left)) { sb.Append('7'); continue; }
                if (input.Equals(Vector.UpLeft)) { sb.Append('8'); continue; }
            }
            return sb.ToString();
        }

        public int CompareTo(Vector other)
        {
            var retval = Horizontal.CompareTo(other.Horizontal);
            if (retval == 0)
                return Vertical.CompareTo(other.Vertical);
            return retval;

        }
    }
}
