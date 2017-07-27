using Acnos.GameLogic.Enums;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Acnos.GameLogic.Actions
{
    public class Player2ReadyToPlace : IAction
    {
        public bool CheckAction(GamePhase phase, GameBoard board)
        {
            return phase == GamePhase.Player2PreSetup;
        }

        public IAction DeepClone()
        {
            return new Player2ReadyToPlace();
        }

        public IEnumerable<IAction> GetActions(GamePhase phase, GameBoard board)
        {
            if (phase == GamePhase.Player2PreSetup)
                yield return this;
        }

        public bool IsAvailable(GamePhase phase, GameBoard board)
        {
            return new Player2ReadyToPlace().GetActions(phase, board).Any();
        }

        public bool PerformAction(GamePhase phase, GameBoard board, out GamePhase newPhase, out GameBoard newBoard)
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
