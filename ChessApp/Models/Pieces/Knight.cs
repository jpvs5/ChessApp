namespace ChessApp.Models.Pieces
{
    internal class Knight : Piece
    {
        public Knight(PlayerColor pieceColor)
        {
            this.Notation = "N";
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
