namespace ChessApp.Models.Pieces
{
    internal abstract class Piece
    {
        public abstract PlayerColor PieceColor { get; }

        public abstract string Notation { get; }

        public abstract bool validMove(Square srcSquare, Square dstSquare);
    }
}
