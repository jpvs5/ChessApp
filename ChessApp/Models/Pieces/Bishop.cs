using System;

namespace ChessApp.Models.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(PlayerColor pieceColor)
        {
            this.Notation = "B";
            PieceColor = pieceColor;
        }

        public override PlayerColor PieceColor { get; }

        public override string Notation { get; }

        public override bool validMove(string srcSquare, string dstSquare)
        {
            int rowDist = Board.rowDist(srcSquare, dstSquare);
            int colDist = Board.colDist(srcSquare, dstSquare);

            if (Math.Abs(rowDist) == Math.Abs(colDist))
            {
                return true;
            }

            return false;
        }
    }
}
