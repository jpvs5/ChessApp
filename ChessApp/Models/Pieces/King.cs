using System;

namespace ChessApp.Models.Pieces
{
    public class King : Piece
    {
        public King(PlayerColor pieceColor)
        {
            this.Notation = "K";
            PieceColor = pieceColor;
        }

        public override PlayerColor PieceColor { get; }

        public override string Notation { get; }

        public override bool validMove(string srcSquare, string dstSquare)
        {
            int rowDist = Math.Abs(Board.rowDist(srcSquare, dstSquare));
            int colDist = Math.Abs(Board.colDist(srcSquare, dstSquare));

            if (rowDist == colDist && rowDist == 1)
            {
                return true;
            }

            if (rowDist == 1 && colDist == 0)
            {
                return true;
            }

            if (rowDist == 0 && colDist == 1)
            {
                return true;
            }

            return false;
        }
    }
}
