﻿using Acnos.GameLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Acnos.GameLogic.Actions
{
    public class Player1PlaceArmy : IAction
    {
        public ShapeOrientation FrontCenter { get; set; }
        public ShapeOrientation FrontLeft { get; set; }
        public ShapeOrientation FrontRight { get; set; }
        public ShapeOrientation MiddleLeft { get; set; }
        public ShapeOrientation MiddleRight { get; set; }
        public ShapeOrientation BackCenter { get; set; }
        public ShapeOrientation BackLeft { get; set; }
        public ShapeOrientation BackRight { get; set; }

        public ShapeOrientation this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return FrontCenter;
                    case 1: return FrontLeft;
                    case 2: return FrontRight;
                    case 3: return MiddleLeft;
                    case 4: return MiddleRight;
                    case 5: return BackCenter;
                    case 6: return BackLeft;
                    case 7: return BackRight;
                    default: throw new IndexOutOfRangeException("Valid range is 0-7");
                }
            }
            set
            {
                switch (index)
                {
                    case 0: FrontCenter = value; break;
                    case 1: FrontLeft = value; break;
                    case 2: FrontRight = value; break;
                    case 3: MiddleLeft = value; break;
                    case 4: MiddleRight = value; break;
                    case 5: BackCenter = value; break;
                    case 6: BackLeft = value; break;
                    case 7: BackRight = value; break;
                    default: throw new IndexOutOfRangeException("Valid range is 0-7");
                }
            }
        }

        public Player1PlaceArmy(ShapeOrientation frontCenter, ShapeOrientation frontLeft,
            ShapeOrientation frontRight, ShapeOrientation middleLeft,
            ShapeOrientation middleRight, ShapeOrientation backCenter,
            ShapeOrientation backLeft, ShapeOrientation backRight)
        {
            FrontCenter = frontCenter;
            FrontLeft = frontLeft;
            FrontRight = frontRight;
            MiddleLeft = middleLeft;
            MiddleRight = middleRight;
            BackCenter = backCenter;
            BackLeft = backLeft;
            BackRight = backRight;
        }

        public Player1PlaceArmy()
        {
            for (var i = 0; i < 8; i++)
                this[i] = new ShapeOrientation(Shape.None, Orientation.Original);
        }

        public bool CheckAction(GamePhase phase, GameBoard board)
        {
            if (phase != GamePhase.Player1SetupArmy) return false;
            var treasure = board.Squares
                .Where(sq => sq.Value.Contents == BoardSquareContents.Piece
                && sq.Value.Piece.Owner == Side.Player1 && sq.Value.Piece.Shapes.Count == 1
                && sq.Value.Piece.Shapes[0].Shape == Shape.Treasure);
            if (!treasure.Any()) return false;
            var treasureLocation = treasure.First().Key;

            var arrowCount = 0;
            for (var i = 0; i < 8; i++)
            {
                var arrows = ArrowCount(this[i].Shape);
                if (arrows == 0) return false;
                arrowCount += arrows;
                if (arrowCount > 20) return false;
            }

            return true;
        }

        private static int ArrowCount(Shape shape)
        {
            var c = (char)shape;
            if ("AZ".Contains(c)) return 1;
            if ("RIBJVL".Contains(c)) return 2;
            if ("TPYSDWNMCF".Contains(c)) return 3;
            if ("XEKG".Contains(c)) return 4;
            return 0;
        }

        public IEnumerable<IAction> GetActions(GamePhase phase, GameBoard board)
        {
            var pieceBag = new List<Shape>(board.Player1Reserve);

            var targetPiece = -1; //Index of first undecided piece to place
            int arrowsLeft = 20; //Number of arrows not yet used
            var pieceLeft = new[] { 0, 0, 0, 0 }; //Number of unplaced pieces
            //with 1, 2, 3, or 4 arrows left to choose from
            var emptySquaresLeft = 0;

            //Identify number of unused pieces of each arrow count in piece bag
            foreach (var piece in pieceBag)
            {
                var idx = ArrowCount(piece);
                if (idx > 0 && idx < 5)
                    pieceLeft[idx - 1]++;
            }

            //Tally each filled or empty army square
            for (var currentPiece = 0; currentPiece < 8; currentPiece++)
            {
                if (this[targetPiece].Shape == Shape.None)
                {
                    //Empty square
                    if (targetPiece == -1)
                        targetPiece = currentPiece;
                    emptySquaresLeft++;
                    continue;
                }

                //Filled square

                //If attempted move uses pieces which aren't in the bag, move is invalid.
                if (!pieceBag.Contains(this[targetPiece].Shape)) yield break;
                pieceBag.Remove(this[targetPiece].Shape);
                var arrows = ArrowCount(this[targetPiece].Shape);
                arrowsLeft -= arrows;
                pieceLeft[arrows]--;
            }

            //Check for illegal setup with too many arrows
            if (arrowsLeft < 0) yield break;

            //Check for fully-populated and legal setup
            if (targetPiece == -1 && arrowsLeft >= 0)
            {
                yield return this;
                yield break;
            }

            //Check for incomplete setup with no legal solution for unfilled squares
            var testArrowsLeft = arrowsLeft;
            for (var i = 0; i < emptySquaresLeft; i++)
            {

            }

            var canPlace = new[] { true, false, false, false };
            for (var i = 1; i < 4; i++)
            {
                if (pieceLeft[i] == 0) continue;
                pieceLeft[i]--;
                if (arrowsLeft - 1 - i >= MinRemainingPieces(pieceLeft, 7 - targetPiece))
                    canPlace[i] = true;
                pieceLeft[i]++;
            }



            yield break;
        }

        private static int MinRemainingPieces(int[] pieceLeft, int count)
        {
            var left = new[] { pieceLeft[0], pieceLeft[1], pieceLeft[2], pieceLeft[3] };
            var retval = 0;
            for (var piece = 0; piece < count; piece++)
            {
                for (var ct = 0; ct < 4; ct++)
                {
                    if (left[ct] > 0)
                    {
                        left[ct]--;
                        retval += (ct + 1);
                        break;
                    }
                }
            }
            return retval;
        }

        public bool PerformAction(GamePhase phase, GameBoard board, out GamePhase newPhase, out GameBoard newBoard)
        {
            throw new NotImplementedException();
        }

        public IAction DeepClone()
        {
            return new Player1PlaceArmy(FrontCenter, FrontLeft, FrontRight,
                MiddleLeft, MiddleRight, BackCenter, BackLeft, BackRight);
        }

        public bool IsAvailable(GamePhase phase, GameBoard board)
        {
            return new Player1PlaceArmy().GetActions(phase, board).Any();
        }
    }
}
