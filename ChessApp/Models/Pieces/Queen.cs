using System;

namespace ChessApp.Models.Pieces
{
    public class Queen : Piece
    {
        public Queen(PlayerColor pieceColor)
        {
            this.Notation = "Q";
            PieceColor = pieceColor;
        }

        public override PlayerColor PieceColor { get; }

        public override string Notation { get; }

        public override bool validMove(string srcSquare, string dstSquare)
        {
            int rowDist = Math.Abs(Board.rowDist(srcSquare, dstSquare));
            int colDist = Math.Abs(Board.colDist(srcSquare, dstSquare));

            if (rowDist == colDist && rowDist != 0)
            {
                return true;
            }

            if (rowDist != 0 && colDist == 0)
            {
                return true;
            }

            if (rowDist == 0 && colDist != 0)
            {
                return true;
            }

            return false;
        }
    }
}
