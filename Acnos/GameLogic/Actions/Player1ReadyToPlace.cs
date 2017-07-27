using Acnos.GameLogic.Enums;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Acnos.GameLogic.Actions
{
    public class Player1ReadyToPlace : IAction
    {
        public bool CheckAction(GamePhase phase, GameBoard board)
        {
            return phase == GamePhase.Player1PreSetup;
        }

        public IAction DeepClone()
        {
            return new Player1ReadyToPlace();
        }

        public IEnumerable<IAction> GetActions(GamePhase phase, GameBoard board)
        {
            if (phase == GamePhase.Player1PreSetup)
                yield return this;
        }

        public bool IsAvailable(GamePhase phase, GameBoard board)
        {
            return GetActions(phase, board).Any();
        }

        public bool PerformAction(GamePhase phase, GameBoard board, out GamePhase newPhase, out GameBoard newBoard)
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
