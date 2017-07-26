using Acnos.GameLogic.Enums;
using System.Collections.Generic;

namespace Acnos.GameLogic.Actions
{
    /// <summary>
    /// Represents some action in a game, either automated setup, forced
    /// game logic, or deliberate player action
    /// </summary>
    public interface IAction : IDeepClone<IAction>
    {
        /// <summary>
        /// Checks if any variations of this action are available
        /// </summary>
        /// <param name="phase">Initial game phase</param>
        /// <param name="board">Initial game board arrangement</param>
        /// <returns>True if any actions of this type are possible from
        /// this phase and board; false otherwise</returns>
        bool IsAvailable(GamePhase phase, GameBoard board);

        /// <summary>
        /// Using the action options set on the object, get alternative or
        /// more specific actions possible from this game state.
        /// </summary>
        /// <param name="phase">Initial game phase</param>
        /// <param name="board">Initial game board arrangement</param>
        /// <returns>Zero or more actions (either full legal actions or 
        /// partial action parts) possible from this game state</returns>
        IEnumerable<IAction> GetActions(GamePhase phase, GameBoard board);

        /// <summary>
        /// Checks if the action is valid and complete for the given game state
        /// </summary>
        /// <param name="phase">Initial game phase</param>
        /// <param name="board">Initial game board arrangement</param>
        /// <returns>True if this action is valid as described, false if it is
        /// illegal, incomplete, or otherwise not appropriate for this phase
        /// of the game</returns>
        bool CheckAction(GamePhase phase, GameBoard board);

        /// <summary>
        /// Performs the provided action on the provided game state, producing
        /// a new game state representing the results of the action
        /// </summary>
        /// <param name="phase">Initial game phase</param>
        /// <param name="board">Initial game board arrangement</param>
        /// <param name="newPhase">New game phase after move completion</param>
        /// <param name="newBoard">New game board arrangement after move completion</param>
        /// <returns>True if this action was performed, false if it could not be
        /// performed because it was illegal, incomplete, or otherwise not appropriate
        /// for this phase of the game</returns>
        bool PerformAction(GamePhase phase, GameBoard board, out GamePhase newPhase, out GameBoard newBoard);
    }
}