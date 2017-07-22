using Acnos.GameLogic.Enums;
using System.Collections.Generic;

namespace Acnos.GameLogic.Actions
{
    class Player2ReadyToPlace : ActionType
    {
        public override bool CheckAction(GamePhase phase, GameBoard board)
        {
            return phase == GamePhase.Player2PreSetup;
        }

        public override ActionType DeepClone()
        {
            return this;
        }

        public override IEnumerable<ActionType> GetActions(GamePhase phase, GameBoard board)
        {
            if (phase == GamePhase.Player2PreSetup)
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

            newPhase = GamePhase.Player2SetupTreasure;
            newBoard = board.DeepClone();
            return true;
        }
    }
}
