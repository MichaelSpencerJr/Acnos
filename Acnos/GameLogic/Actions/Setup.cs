using Acnos.GameLogic.Enums;
using System.Collections.Generic;

namespace Acnos.GameLogic.Actions
{
    /// <summary>
    /// From any game state, start a new game and set game state to
    /// start of player 1's setup phase
    /// </summary>
    public class Setup : ActionType
    {
        /// <summary>
        /// Returns self only, as there's only one way to set up the game board
        /// </summary>
        /// <returns>self</returns>
        public override IEnumerable<ActionType> GetActions(GamePhase phase, GameBoard board)
        {
            if (phase == GamePhase.None)
                yield return this;
        }

        /// <summary>
        /// Confirms game phase is unset, indicating need to set up empty game board
        /// </summary>
        /// <param name="phase">Initial game phase</param>
        /// <param name="board">Initial board state</param>
        /// <returns>True only if game phase is None</returns>
        public override bool CheckAction(GamePhase phase, GameBoard board)
        {
            return phase == GamePhase.None;
        }

        /// <summary>
        /// Performs setup of new game board, prepared for player 1 to start placing
        /// treasure and initial pieces
        /// </summary>
        /// <param name="phase">Game phase before action</param>
        /// <param name="board">Board state before action, ignored</param>
        /// <param name="newPhase">Game phase after action</param>
        /// <param name="newBoard">Board state after action</param>
        /// <returns>True if action was performed successfully</returns>
        public override bool PerformAction(GamePhase phase, GameBoard board, out GamePhase newPhase, out GameBoard newBoard)
        {
            if (phase != GamePhase.None)
            {
                newPhase = phase;
                newBoard = board;
                return false;
            }

            newPhase = GamePhase.Player1PreSetup;
            newBoard = new GameBoard();
            for (var i = 1; i <= 8; i++)
                for (var j = 1; j <= 8; j++)
                {
                    var newSquare = new BoardSquare(new BoardLocation(i, j), BoardSquareContents.Empty);
                    newBoard.Squares[newSquare.Position] = newSquare;
                }

            foreach (var c in "AZZRIBJVLTPYSDWNMCFXEKG")
            {
                newBoard.Player1Reserve.Add((Shape)c);
                newBoard.Player2Reserve.Add((Shape)c);
            }

            return true;
        }

        public override ActionType DeepClone()
        {
            return this;
        }
    }
}
