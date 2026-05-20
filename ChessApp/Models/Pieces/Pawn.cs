using System;

namespace ChessApp.Models.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(PlayerColor pieceColor)
        {
            this.Notation = "";
            PieceColor = pieceColor;
            CanDoubleStep = true;
        }

        public bool CanDoubleStep { get; set; }

        public override PlayerColor PieceColor { get; }

        public override string Notation { get; }

        public override bool validMove(string srcSquare, string dstSquare)
        {
            int rowDist = Board.rowDist(srcSquare, dstSquare);
            int colDist = Board.colDist(srcSquare, dstSquare);

            if (PieceColor == PlayerColor.White)
            {
                if (rowDist == 1 && (Math.Abs(colDist) <= 1))
                {
                    return true;
                }

                if (rowDist == 2 && CanDoubleStep && colDist == 0)
                {
                    return true;
                }
            }
            else
            {
                if (rowDist == -1 && (Math.Abs(colDist) <= 1))
                {
                    return true;
                }

                if (rowDist == -2 && CanDoubleStep && colDist == 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
