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
            return false;
        }
    }
}
