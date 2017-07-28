using Acnos.GameLogic;
using Acnos.GameLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acnos.SpecFlow.GameLogic
{
    static class Helpers
    {
        public static GameBoard GameBoardFromState(GameBoardRow[] boardRows, Shape player1Next, Shape player2Next, string player1Bag, string player2Bag)
        {
            var board = new GameBoard();
            for (var row = 0; row < 8; row++)
                for (var col = 0; col < 8; col++)
                {
                    var loc = new BoardLocation(row + 1, col + 1);
                    var contents = boardRows[row][col]?.Trim()?.ToUpper() ?? "";
                    if (string.IsNullOrWhiteSpace(contents))
                        board.Squares[loc] = new BoardSquare(loc, BoardSquareContents.Empty);
                    else if (contents == "B" || contents == "BLOCKADE")
                        board.Squares[loc] = new BoardSquare(loc, BoardSquareContents.Blockade);
                    else
                        board.Squares[loc] = new BoardSquare(loc, Piece.FromString(contents));
                }
            board.Player1Next = player1Next;
            board.Player1Reserve = player1Bag.Select(c => (Shape)c).ToList();
            board.Player2Next = player2Next;
            board.Player2Reserve = player2Bag.Select(c => (Shape)c).ToList();
            return board;
        }
    }
}
