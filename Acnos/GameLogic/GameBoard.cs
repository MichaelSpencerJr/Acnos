using Acnos.GameLogic.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Acnos.GameLogic
{
    public class GameBoard : IDeepClone<GameBoard>
    {
        private Dictionary<BoardLocation, BoardSquare> _squares = new Dictionary<BoardLocation, BoardSquare>();
        public Dictionary<BoardLocation, BoardSquare> Squares { get => _squares; set => _squares = value; }

        private Shape _player1next = Shape.None;
        public Shape Player1Next { get => _player1next; set => _player1next = value; }

        private Shape _player2next = Shape.None;
        public Shape Player2Next { get => _player2next; set => _player2next = value; }

        private List<Shape> _player1reserve = new List<Shape>();
        public List<Shape> Player1Reserve { get => _player1reserve; set => _player1reserve = value; }

        private List<Shape> _player2reserve = new List<Shape>();
        public List<Shape> Player2Reserve { get => _player2reserve; set => _player2reserve = value; }

        public GameBoard DeepClone()
        {
            var retval = new GameBoard { Player1Next = this.Player1Next, Player2Next = this.Player2Next };
            foreach (var square in this.Squares)
                retval.Squares.Add(square.Key, square.Value.DeepClone());
            retval.Player1Reserve.AddRange(this.Player1Reserve);
            retval.Player2Reserve.AddRange(this.Player2Reserve);
            return retval;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            if (Squares.Values.Any(sq => sq.Piece?.Owner == Side.Player1))
            {
                sb.AppendLine("Player 1 Pieces:");
                foreach (var square in Squares.Values.Where(sq => sq.Piece?.Owner == Side.Player1))
                    sb.Append("    ").AppendLine(square.ToString());
                sb.AppendLine();
            }

            if (Squares.Values.Any(sq => sq.Piece?.Owner == Side.Player2))
            {
                sb.AppendLine("Player 2 Pieces:");
                foreach (var square in Squares.Values.Where(sq => sq.Piece?.Owner == Side.Player2))
                    sb.Append("    ").AppendLine(square.ToString());
                sb.AppendLine();
            }

            if (Squares.Values.Any(sq => sq.Contents == BoardSquareContents.Blockade))
            {
                var blockades = Squares.Values.Where(sq => sq.Contents == BoardSquareContents.Blockade).Select(sq => sq.Position).ToArray();
                switch (blockades.Length)
                {
                    case 0:
                        break;
                    case 1:
                        sb.AppendLine($"Blockade at {blockades[0]}");
                        break;
                    case 2:
                        sb.AppendLine($"Blockades at {blockades[0]} and {blockades[1]}");
                        break;
                    default:
                        sb.Append("Blockades at");
                        for (var i = 0; i < blockades.Length - 1; i++)
                            sb.Append($" {blockades[i]},");
                        sb.AppendLine($" and {blockades[blockades.Length - 1]}");
                        break;
                }
            }

            sb.Append($"Next Pieces: Player 1 [{Player1Next,-9}] - Player 2 [{Player2Next,-9}]");

            if (Player1Reserve.Any())
            {
                switch (Player1Reserve.Count)
                {
                    case 1:
                        sb.AppendLine($"Player 1 Reserve Piece: {Player1Reserve[0]}");
                        break;
                    case 2:
                        sb.AppendLine($"Player 1 Reserve Pieces: {Player1Reserve[0]} and {Player1Reserve[1]}");
                        break;
                    default:
                        sb.Append("Player 1 Reserve Pieces:");
                        for (var i = 0; i < Player1Reserve.Count - 1; i++)
                            sb.Append($" {Player1Reserve[i]},");
                        sb.AppendLine($" and {Player1Reserve[Player1Reserve.Count - 1]}");
                        break;
                }
            }

            if (Player2Reserve.Any())
            {
                switch (Player2Reserve.Count)
                {
                    case 1:
                        sb.AppendLine($"Player 2 Reserve Piece: {Player2Reserve[0]}");
                        break;
                    case 2:
                        sb.AppendLine($"Player 2 Reserve Pieces: {Player2Reserve[0]} and {Player2Reserve[1]}");
                        break;
                    default:
                        sb.Append("Player 2 Reserve Pieces:");
                        for (var i = 0; i < Player2Reserve.Count - 1; i++)
                            sb.Append($" {Player2Reserve[i]},");
                        sb.AppendLine($" and {Player2Reserve[Player1Reserve.Count - 1]}");
                        break;
                }
            }

            return sb.ToString().Trim();
        }
    }
}
