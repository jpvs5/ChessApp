using System;
using System.Collections.Generic;
using System.Text;

namespace ChessApp.Models.Pieces
{
    internal class Bishop : Piece
    {
        public Bishop(PlayerColor pieceColor)
        {
            this.Notation = "B";
            PieceColor = pieceColor;
        }

        public override PlayerColor PieceColor { get; }

        public override string Notation { get; }

        public override bool validMove(Square srcSquare, Square dstSquare)
        {
            return false;
        }
    }
}
