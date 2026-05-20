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
            return false;
        }
    }
}
