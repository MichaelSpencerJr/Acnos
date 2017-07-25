using Acnos.GameLogic.Enums;
using System.Collections.Generic;

namespace Acnos.GameLogic.Actions
{
    public class Player1ReadyToPlace : ActionType
    {
        public override bool CheckAction(GamePhase phase, GameBoard board)
        {
            return phase == GamePhase.Player1PreSetup;
        }

        public override ActionType DeepClone()
        {
            return new Player1ReadyToPlace();
        }

        public override IEnumerable<ActionType> GetActions(GamePhase phase, GameBoard board)
        {
            if (phase == GamePhase.Player1PreSetup)
                yield return this;
        }

        public override bool PerformAction(GamePhase phase, GameBoard board, out GamePhase newPhase, out GameBoard newBoard)
        {
            if (!CheckAction(phase, board))
            {
                newPhase = phase;
                newBoard = board;
                return false;
            }

            newPhase = GamePhase.Player1SetupTreasure;
            newBoard = board.DeepClone();
            return true;
        }
    }
}
