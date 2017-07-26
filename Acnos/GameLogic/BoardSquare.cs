using Acnos.GameLogic.Enums;
using System;

namespace Acnos.GameLogic
{
    public class BoardSquare : IDeepClone<BoardSquare>
    {
        public BoardLocation Position { get; set; }

        private BoardSquareContents _contents = BoardSquareContents.Empty;
        public BoardSquareContents Contents
        {
            get
            {
                return _contents;
            }
            set
            {
                if (value != BoardSquareContents.Piece)
                    _piece = null;
                _contents = value;
            }
        }

        private Piece _piece;
        public Piece Piece
        {
            get
            {
                return _contents == BoardSquareContents.Piece ? _piece : null;
            }
            set
            {
                if (value != null)
                    _contents = BoardSquareContents.Piece;
                _piece = value;
            }
        }

        public BoardSquare(BoardLocation position, BoardSquareContents contents, Piece piece)
        {
            Position = position;
            _contents = contents;
            _piece = piece;
        }

        public BoardSquare(BoardLocation position, BoardSquareContents contents)
        {
            if (contents == BoardSquareContents.Piece)
                throw new ArgumentException("Piece object must be provided instead", nameof(contents));
            Position = position;
            Contents = contents;
        }

        public BoardSquare(BoardLocation position, Piece piece)
        {
            Position = position;
            Piece = piece ?? throw new ArgumentNullException("Contents must be provided instead if square does not contain a piece", nameof(piece));
        }

        public override string ToString()
        {
            switch (_contents)
            {
                case BoardSquareContents.Empty:
                    return $"{Position}:Empty";
                case BoardSquareContents.Blockade:
                    return $"{Position}:Blockade";
                case BoardSquareContents.Piece:
                    return $"{Position}:{_piece}";
                default:
                    return "Invalid Board Square Contents";
            }
        }

        public BoardSquare DeepClone()
        {
            return new BoardSquare(this.Position, this.Contents, this.Piece?.DeepClone());
        }
    }
}
