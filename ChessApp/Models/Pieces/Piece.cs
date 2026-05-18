namespace ChessApp.Models.Pieces
{
    public abstract class Piece
    {
        public abstract PlayerColor PieceColor { get; }

        public abstract string Notation { get; }

        public abstract bool validMove(string srcSquare, string dstSquare);
    }
}
