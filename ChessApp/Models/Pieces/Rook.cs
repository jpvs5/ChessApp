namespace ChessApp.Models.Pieces
{
    public class Rook : Piece
    {
        public Rook(PlayerColor pieceColor)
        {
            this.Notation = "R";
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
