using System;

namespace Acnos.GameLogic
{
    public struct BoardLocation : IComparable<BoardLocation>
    {
        public int Layer { get; set; }
        public int Column { get; set; }

        public BoardLocation(int layer, int column)
        {
            Layer = layer;
            Column = column;
        }

        public override string ToString()
        {
            return $"{(char)('@' + Column)}{Layer}";
        }

        public int CompareTo(BoardLocation other)
        {
            var retval = Layer.CompareTo(other.Layer);
            if (retval != 0) return retval;
            return Column.CompareTo(other.Column);
        }

        public static Vector operator -(BoardLocation left, BoardLocation right)
        {
            return new Vector(left.Column - right.Column, left.Layer - right.Layer);
        }

        public static Vector operator +(BoardLocation left, BoardLocation right)
        {
            return new Vector(left.Column + right.Column, left.Layer + right.Layer);
        }

        public static BoardLocation operator -(BoardLocation left, Vector right)
        {
            return new BoardLocation(left.Column - right.Horizontal, left.Layer - right.Vertical);
        }

        public static BoardLocation operator +(BoardLocation left, Vector right)
        {
            return new BoardLocation(left.Column + right.Horizontal, left.Layer + right.Vertical);
        }

        public static BoardLocation operator +(Vector left, BoardLocation right) => right + left;

        public static readonly BoardLocation A1 = new BoardLocation(1, 1);
        public static readonly BoardLocation B1 = new BoardLocation(1, 2);
        public static readonly BoardLocation C1 = new BoardLocation(1, 3);
        public static readonly BoardLocation D1 = new BoardLocation(1, 4);
        public static readonly BoardLocation E1 = new BoardLocation(1, 5);
        public static readonly BoardLocation F1 = new BoardLocation(1, 6);
        public static readonly BoardLocation G1 = new BoardLocation(1, 7);
        public static readonly BoardLocation H1 = new BoardLocation(1, 8);
        public static readonly BoardLocation A2 = new BoardLocation(2, 1);
        public static readonly BoardLocation B2 = new BoardLocation(2, 2);
        public static readonly BoardLocation C2 = new BoardLocation(2, 3);
        public static readonly BoardLocation D2 = new BoardLocation(2, 4);
        public static readonly BoardLocation E2 = new BoardLocation(2, 5);
        public static readonly BoardLocation F2 = new BoardLocation(2, 6);
        public static readonly BoardLocation G2 = new BoardLocation(2, 7);
        public static readonly BoardLocation H2 = new BoardLocation(2, 8);
        public static readonly BoardLocation A3 = new BoardLocation(3, 1);
        public static readonly BoardLocation B3 = new BoardLocation(3, 2);
        public static readonly BoardLocation C3 = new BoardLocation(3, 3);
        public static readonly BoardLocation D3 = new BoardLocation(3, 4);
        public static readonly BoardLocation E3 = new BoardLocation(3, 5);
        public static readonly BoardLocation F3 = new BoardLocation(3, 6);
        public static readonly BoardLocation G3 = new BoardLocation(3, 7);
        public static readonly BoardLocation H3 = new BoardLocation(3, 8);
        public static readonly BoardLocation A4 = new BoardLocation(4, 1);
        public static readonly BoardLocation B4 = new BoardLocation(4, 2);
        public static readonly BoardLocation C4 = new BoardLocation(4, 3);
        public static readonly BoardLocation D4 = new BoardLocation(4, 4);
        public static readonly BoardLocation E4 = new BoardLocation(4, 5);
        public static readonly BoardLocation F4 = new BoardLocation(4, 6);
        public static readonly BoardLocation G4 = new BoardLocation(4, 7);
        public static readonly BoardLocation H4 = new BoardLocation(4, 8);
        public static readonly BoardLocation A5 = new BoardLocation(5, 1);
        public static readonly BoardLocation B5 = new BoardLocation(5, 2);
        public static readonly BoardLocation C5 = new BoardLocation(5, 3);
        public static readonly BoardLocation D5 = new BoardLocation(5, 4);
        public static readonly BoardLocation E5 = new BoardLocation(5, 5);
        public static readonly BoardLocation F5 = new BoardLocation(5, 6);
        public static readonly BoardLocation G5 = new BoardLocation(5, 7);
        public static readonly BoardLocation H5 = new BoardLocation(5, 8);
        public static readonly BoardLocation A6 = new BoardLocation(6, 1);
        public static readonly BoardLocation B6 = new BoardLocation(6, 2);
        public static readonly BoardLocation C6 = new BoardLocation(6, 3);
        public static readonly BoardLocation D6 = new BoardLocation(6, 4);
        public static readonly BoardLocation E6 = new BoardLocation(6, 5);
        public static readonly BoardLocation F6 = new BoardLocation(6, 6);
        public static readonly BoardLocation G6 = new BoardLocation(6, 7);
        public static readonly BoardLocation H6 = new BoardLocation(6, 8);
        public static readonly BoardLocation A7 = new BoardLocation(7, 1);
        public static readonly BoardLocation B7 = new BoardLocation(7, 2);
        public static readonly BoardLocation C7 = new BoardLocation(7, 3);
        public static readonly BoardLocation D7 = new BoardLocation(7, 4);
        public static readonly BoardLocation E7 = new BoardLocation(7, 5);
        public static readonly BoardLocation F7 = new BoardLocation(7, 6);
        public static readonly BoardLocation G7 = new BoardLocation(7, 7);
        public static readonly BoardLocation H7 = new BoardLocation(7, 8);
        public static readonly BoardLocation A8 = new BoardLocation(8, 1);
        public static readonly BoardLocation B8 = new BoardLocation(8, 2);
        public static readonly BoardLocation C8 = new BoardLocation(8, 3);
        public static readonly BoardLocation D8 = new BoardLocation(8, 4);
        public static readonly BoardLocation E8 = new BoardLocation(8, 5);
        public static readonly BoardLocation F8 = new BoardLocation(8, 6);
        public static readonly BoardLocation G8 = new BoardLocation(8, 7);
        public static readonly BoardLocation H8 = new BoardLocation(8, 8);
    }
}
