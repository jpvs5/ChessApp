using System;

namespace ChessApp.Models.Pieces
{
    public class Knight : Piece
    {
        public Knight(PlayerColor pieceColor)
        {
            this.Notation = "N";
            PieceColor = pieceColor;
        }

        public override PlayerColor PieceColor { get; }

        public override string Notation { get; }

        public override bool validMove(string srcSquare, string dstSquare)
        {
            int rowDist = Math.Abs(Board.rowDist(srcSquare, dstSquare));
            int colDist = Math.Abs(Board.colDist(srcSquare, dstSquare));

            if (rowDist == 2 && colDist == 1)
            {
                return true;
            } else if (rowDist == 1 && colDist == 2)
            {
                return true;
            }

            return false;
        }
    }
}
