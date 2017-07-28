using Acnos.GameLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Acnos.GameLogic
{
    /// <summary>
    /// Represents a game piece, which has a player owner, an unordered collection of
    /// oriented (rotated and/or flipped) shapes, and a maximum stack height
    /// </summary>
    public class Piece : IDeepClone<Piece>
    {
        public Piece(Side owner, int stackLimit, ShapeOrientationCollection shapes)
        {
            Owner = owner;
            StackLimit = stackLimit;
            Shapes = shapes;
        }

        public Piece(Side owner, int stackLimit, params ShapeOrientation[] shapes)
        {
            Owner = owner;
            StackLimit = stackLimit;
            Shapes = new ShapeOrientationCollection(shapes, true);
        }

        private string _shapeString = null;

        public static Piece FromString(string contents)
        {
            if (string.IsNullOrWhiteSpace(contents)) return null;
            var sidePart = contents[0];
            var limitPart = "(2)";
            var skipIdx = 1;
            if (contents.Length > 1 && contents[1] == '(' && contents.Contains(")"))
            {
                skipIdx = contents.IndexOf(')') + 1;
                limitPart = contents.Substring(1, skipIdx - 2);
            }
            int limit;
            if (!int.TryParse(limitPart.Substring(1, limitPart.Length - 2), out limit))
                limit = 2;
            var side = "1WAwa".Contains(sidePart) ? Side.Player1 : Side.Player2;
            return new Piece(side, limit, new ShapeOrientationCollection(contents.Substring(skipIdx).Split('-').Select(ShapeOrientationFromString), true));
        }

        private static ShapeOrientation ShapeOrientationFromString(string part)
        {
            var shape = (Shape)part[0];
            var vectors = Piece.GetNonOrientedVectors(shape);
            for (var orientation = Orientation.Original; orientation <= Orientation.LeftFlip; orientation++)
            {
                if (part.Substring(1).Equals(Vector.DistinctVectorsToString(Piece.OrientVectors(vectors, orientation))))
                    return new ShapeOrientation(shape, orientation);
            }
            return new ShapeOrientation(Shape.None, Orientation.Original);
        }

        /// <summary>
        /// Caching accessor for Shapes.ToString(), which sorts the pieces in the stack
        /// and describes them with a unique order-independent string.  This value represents
        /// the pieces in the stack along with their orientation, and can be used to look
        /// up a pre-computed set of possible movement paths, which themselves combine with
        /// a set of game board border relative positions and blockaded square relative positions
        /// to yield a set of possible legal moves.
        /// 
        /// It's slightly expensive to sort and output the set of pieces every time we
        /// want this string, so the value is cached and only regenerated when needed.
        /// </summary>
        private string ShapeString
        {
            get
            {
                if (Shapes.Modified || _shapeString == null)
                {
                    _shapeString = Shapes.ToString();
                    Shapes.Modified = false;
                }
                return _shapeString;
            }
        }

        /// <summary>
        /// Which player / side owns this piece?
        /// </summary>
        public Side Owner { get; set; }

        /// <summary>
        /// Current maximum number of shapes in this piece's stack
        /// </summary>
        public int StackLimit { get; set; }

        /// <summary>
        /// List of one or more shapes, oriented and stacked to create a game piece
        /// </summary>
        public ShapeOrientationCollection Shapes { get; set; }

        /// <summary>
        /// String notation for the current game piece, in the format:
        /// Player(potential)-FirstPiece-SecondPiece-ThirdPiece...
        /// Player is a single letter W or B for players 1 or 2 respectively.
        /// Potential is an integer indicating the current stack limit, which starts at 2
        /// and is incremented each time the piece passes the opponent's side and returns
        /// to their own side.
        /// Each piece is the shape letter followed by 1-4 digits indicating the valid
        /// movement directions.
        /// Pieces are sorted in order of shape letter (alphabetically) and then by the 
        /// current orientation, so two pieces containing the same shapes in the same orientations
        /// should resolve to the same notation, without regard for the order in which the pieces
        /// were combined.
        /// </summary>
        /// <returns>Piece description in game notation</returns>
        public override string ToString() => $"{(char)Owner}({StackLimit}){ShapeString}";

        /// <summary>
        /// Returns a set of vectors describing the possible moves for each
        /// unrotated unflipped shape
        /// </summary>
        /// <param name="shape">Input shape</param>
        /// <returns>Zero or more vector objects</returns>
        public static IEnumerable<Vector> GetNonOrientedVectors(Shape shape)
        {
            //This function is pure data entry, copied from page 19 of the ACNOS PDF
            switch (shape)
            {
                case Shape.Ray:
                    yield return Vector.UpRight;
                    yield break;
                case Shape.Blades:
                    yield return Vector.Up;
                    yield return Vector.UpRight;
                    yield break;
                case Shape.Claw:
                    yield return Vector.UpLeft;
                    yield return Vector.Up;
                    yield return Vector.DownRight;
                    yield break;
                case Shape.Dancer:
                    yield return Vector.Up;
                    yield return Vector.Left;
                    yield return Vector.DownRight;
                    yield break;
                case Shape.Eagle:
                    yield return Vector.UpLeft;
                    yield return Vector.Up;
                    yield return Vector.UpRight;
                    yield return Vector.Down;
                    yield break;
                case Shape.Finch:
                    yield return Vector.Up;
                    yield return Vector.UpRight;
                    yield return Vector.DownRight;
                    yield break;
                case Shape.Cross:
                    yield return Vector.Up;
                    yield return Vector.Left;
                    yield return Vector.Down;
                    yield return Vector.Right;
                    yield break;
                case Shape.Diamond:
                    yield return Vector.Left;
                    yield return Vector.Right;
                    yield break;
                case Shape.Boomerang:
                    yield return Vector.Up;
                    yield return Vector.DownRight;
                    yield break;
                case Shape.Hedgehog:
                    yield return Vector.UpLeft;
                    yield return Vector.UpRight;
                    yield return Vector.Left;
                    yield return Vector.Right;
                    yield break;
                case Shape.Corner:
                    yield return Vector.Left;
                    yield return Vector.Up;
                    yield break;
                case Shape.Talon:
                    yield return Vector.UpLeft;
                    yield return Vector.Up;
                    yield return Vector.Left;
                    yield break;
                case Shape.Corn:
                    yield return Vector.Up;
                    yield return Vector.UpRight;
                    yield return Vector.Down;
                    yield break;
                case Shape.Treasure:
                    yield break;
                case Shape.Tulip:
                    yield return Vector.UpLeft;
                    yield return Vector.Up;
                    yield return Vector.Right;
                    yield break;
                case Shape.Ramp:
                    yield return Vector.UpRight;
                    yield return Vector.DownLeft;
                    yield break;
                case Shape.Sickle:
                    yield return Vector.UpLeft;
                    yield return Vector.UpRight;
                    yield return Vector.DownLeft;
                    yield break;
                case Shape.Hat:
                    yield return Vector.Up;
                    yield return Vector.Left;
                    yield return Vector.Right;
                    yield break;
                case Shape.Peak:
                    yield return Vector.UpLeft;
                    yield return Vector.UpRight;
                    yield break;
                case Shape.Crown:
                    yield return Vector.UpLeft;
                    yield return Vector.Up;
                    yield return Vector.UpRight;
                    yield break;
                case Shape.Mark:
                    yield return Vector.UpLeft;
                    yield return Vector.UpRight;
                    yield return Vector.DownLeft;
                    yield return Vector.DownRight;
                    yield break;
                case Shape.Tower:
                    yield return Vector.Up;
                    yield return Vector.DownLeft;
                    yield return Vector.DownRight;
                    yield break;
                case Shape.Tear:
                    yield return Vector.Up;
                    yield break;
                case Shape.None:
                    yield break;
                default:
                    yield break;
            }
        }

        /// <summary>
        /// Transforms an unoriented vector to the provided orientation
        /// </summary>
        /// <param name="unoriented">Unoriented vector</param>
        /// <param name="orientation">Orientation to rotate or flip vector to</param>
        /// <returns>Properly oriented vector</returns>
        public static Vector OrientVector(Vector unoriented, Orientation orientation)
        {
            switch (orientation)
            {
                case Orientation.Original:
                    return unoriented;
                case Orientation.Flip:
                    return new Vector(-unoriented.Horizontal, unoriented.Vertical);
                case Orientation.UpsideDown:
                    return new Vector(-unoriented.Horizontal, -unoriented.Vertical);
                case Orientation.UpsideDownFlip:
                    return new Vector(unoriented.Horizontal, -unoriented.Vertical);
                case Orientation.Right:
                    return new Vector(-unoriented.Vertical, unoriented.Horizontal);
                case Orientation.RightFlip:
                    return new Vector(unoriented.Vertical, unoriented.Horizontal);
                case Orientation.Left:
                    return new Vector(unoriented.Vertical, -unoriented.Horizontal);
                case Orientation.LeftFlip:
                    return new Vector(-unoriented.Vertical, -unoriented.Horizontal);
                default:
                    throw new ArgumentException("Orientation value was incorrect", nameof(orientation));
            }
        }

        /// <summary>
        /// Transforms a set of unoriented vectors to the provided orientation
        /// </summary>
        /// <param name="unoriented">Set of unoriented vectors</param>
        /// <param name="orientation">Orientation to rotate or flip vectors to</param>
        /// <returns>Set of properly oriented vectors</returns>
        public static IEnumerable<Vector> OrientVectors(IEnumerable<Vector> unoriented, Orientation orientation)
        {
            if (unoriented == null) yield break;
            foreach (var vector in unoriented)
                yield return OrientVector(vector, orientation);
        }

        /// <summary>
        /// Transforms an orientation using a rotate or flip action, yielding a new orientation
        /// </summary>
        /// <param name="original">Orientation before action</param>
        /// <param name="action">Rotate or flip action to perform</param>
        /// <returns>Orientation after action</returns>
        public static Orientation RotateOrientation(Orientation original, RotateAction action)
        {
            switch (action)
            {
                case RotateAction.None:
                    return original;
                case RotateAction.TurnRight:
                    return (Orientation)(((int)original + 2) % 8);
                case RotateAction.TurnAround:
                    return original ^ Orientation.UpsideDown;
                case RotateAction.TurnLeft:
                    return (Orientation)(((int)original + 6) % 8);
                case RotateAction.FlipHorizontal:
                    return original ^ Orientation.Flip ^ (Orientation)((int)(original & Orientation.Right) << 1);
                case RotateAction.FlipTopRight:
                    return original ^ Orientation.RightFlip;
                case RotateAction.FlipVertical:
                    return original ^ Orientation.UpsideDownFlip ^ (Orientation)((int)(original & Orientation.Right) << 1);
                case RotateAction.FlipTopLeft:
                    return original ^ Orientation.LeftFlip;
                default:
                    throw new ArgumentException("Action value was invalid", nameof(action));
            }
        }

        /// <summary>
        /// Given an original orientation and a resulting orientation, identifies which
        /// rotate action transforms from original to result.
        /// </summary>
        /// <param name="original">Original orientation</param>
        /// <param name="result">Resulting orientation</param>
        /// <returns>Rotate action that, when applied to the original orientation, results
        /// in the indicated result orientation.</returns>
        public static RotateAction GetRotation(Orientation original, Orientation result)
        {
            var isFlip = ((int)(original ^ result) & 0x01) << 2;
            return (RotateAction)(((4 + ((isFlip > 0 ?
                ((int)original + (int)result)
                : ((int)result - (int)original)
                ) >> 1)) % 4) | isFlip);
        }

        public Piece DeepClone()
        {
            return new Piece(this.Owner, this.StackLimit, this.Shapes.DeepClone());
        }
    }
}
