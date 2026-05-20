namespace ChessApp.Models.Pieces
{
    public class Queen : Piece
    {
        public Queen(PlayerColor pieceColor)
        {
            this.Notation = "Q";
            PieceColor = pieceColor;
        }

        public override PlayerColor PieceColor { get; }

        public override string Notation { get; }

        public override bool validMove(string srcSquare, string dstSquare)
        {
            return false;
        }
    }
}
