namespace ChessApp.Models.Pieces
{
    internal class Queen : Piece
    {
        public Queen(PlayerColor pieceColor)
        {
            this.Notation = "Q";
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
