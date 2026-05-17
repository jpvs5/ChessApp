namespace ChessApp.Models.Pieces
{
    internal class King : Piece
    {
        public King(PlayerColor pieceColor)
        {
            this.Notation = "K";
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
