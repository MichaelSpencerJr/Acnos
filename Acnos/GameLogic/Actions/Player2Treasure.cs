using Acnos.GameLogic.Enums;
using System.Collections.Generic;

namespace Acnos.GameLogic.Actions
{
    public class Player2Treasure : IAction
    {
        public Player2Treasure(BoardLocation treasureLocation)
        {
            TreasureLocation = treasureLocation;
        }

        public BoardLocation TreasureLocation { get; set; }

        public override bool CheckAction(GamePhase phase, GameBoard board)
        {
            return phase == GamePhase.Player2SetupTreasure && TreasureLocation.Layer == 7
                && TreasureLocation.Column > 1 && TreasureLocation.Column < 8;
        }

        public override IAction DeepClone()
        {
            return new Player2Treasure(this.TreasureLocation);
        }

        public override IEnumerable<IAction> GetActions(GamePhase phase, GameBoard board)
        {
            if (phase == GamePhase.Player2SetupTreasure)
            {
                yield return new Player1Treasure(BoardLocation.B7);
                yield return new Player1Treasure(BoardLocation.C7);
                yield return new Player1Treasure(BoardLocation.D7);
                yield return new Player1Treasure(BoardLocation.E7);
                yield return new Player1Treasure(BoardLocation.F7);
                yield return new Player1Treasure(BoardLocation.G7);
            }
        }

        public override bool PerformAction(GamePhase phase, GameBoard board, out GamePhase newPhase, out GameBoard newBoard)
        {
            if (!CheckAction(phase, board))
            {
                newPhase = phase;
                newBoard = board;
                return false;
            }

            newPhase = GamePhase.Player2SetupArmy;
            newBoard = board.DeepClone();
            newBoard.Squares[TreasureLocation] = new BoardSquare(TreasureLocation,
                new Piece(Side.Player2, 1,
                new ShapeOrientationCollection {
                    new ShapeOrientation(Shape.Treasure, Orientation.Original) }));

            return true;
        }
    }
}
