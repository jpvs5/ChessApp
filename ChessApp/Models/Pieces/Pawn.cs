namespace ChessApp.Models.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(PlayerColor pieceColor)
        {
            this.Notation = "";
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
