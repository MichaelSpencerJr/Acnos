using Acnos.GameLogic.Enums;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Acnos.GameLogic.Actions
{
    public class Player1Treasure : IAction
    {
        public Player1Treasure()
        {
            TreasureLocation = BoardLocation.B2;
        }

        public Player1Treasure(BoardLocation treasureLocation)
        {
            TreasureLocation = treasureLocation;
        }

        public BoardLocation TreasureLocation { get; set; }

        public bool CheckAction(GamePhase phase, GameBoard board)
        {
            return phase == GamePhase.Player1SetupTreasure && TreasureLocation.Layer == 2
                && TreasureLocation.Column > 1 && TreasureLocation.Column < 8;
        }

        public IAction DeepClone()
        {
            return new Player1Treasure(this.TreasureLocation);
        }

        public IEnumerable<IAction> GetActions(GamePhase phase, GameBoard board)
        {
            if (phase == GamePhase.Player1SetupTreasure)
            {
                yield return new Player1Treasure(BoardLocation.B2);
                yield return new Player1Treasure(BoardLocation.C2);
                yield return new Player1Treasure(BoardLocation.D2);
                yield return new Player1Treasure(BoardLocation.E2);
                yield return new Player1Treasure(BoardLocation.F2);
                yield return new Player1Treasure(BoardLocation.G2);
            }
        }

        public bool IsAvailable(GamePhase phase, GameBoard board)
        {
            return new Player1Treasure().GetActions(phase, board).Any();

        }

        public bool PerformAction(GamePhase phase, GameBoard board, out GamePhase newPhase, out GameBoard newBoard)
        {
            if (!CheckAction(phase, board))
            {
                newPhase = phase;
                newBoard = board;
                return false;
            }

            newPhase = GamePhase.Player1SetupArmy;
            newBoard = board.DeepClone();
            newBoard.Squares[TreasureLocation] = new BoardSquare(TreasureLocation,
                new Piece(Side.Player1, 1,
                new ShapeOrientationCollection {
                    new ShapeOrientation(Shape.Treasure, Orientation.Original) }));

            return true;
        }
    }
}
