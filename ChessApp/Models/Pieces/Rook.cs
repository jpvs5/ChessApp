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
            int rowDist = Board.rowDist(srcSquare, dstSquare);
            int colDist = Board.colDist(srcSquare, dstSquare);

            if (rowDist != 0 && colDist != 0)
            {
                return false;
            } else if (rowDist == 0 && colDist == 0)
            {
                return false;
            }

            return true;
        }
    }
}
