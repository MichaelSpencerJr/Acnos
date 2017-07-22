using Acnos.GameLogic.Actions;
using Acnos.GameLogic.Enums;

namespace Acnos.GameLogic
{
    class GameAction : IDeepClone<GameAction>
    {
        public GameAction(GamePhase state, GameBoard board, ActionType action)
        {
            State = state;
            Board = board;
            Action = action;
        }

        public GamePhase State { get; set; }

        public GameBoard Board { get; set; }

        public ActionType Action { get; set; }

        public GameAction DeepClone()
        {
            return new GameAction(this.State, this.Board.DeepClone(), this.Action.DeepClone());
        }
    }
}
