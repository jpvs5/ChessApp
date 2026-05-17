using ChessApp.Models.Pieces;

namespace ChessApp.Models
{
    public class Square
    {
        public Square(string notation, Piece? piece)
        {
            this._notation = notation;
            this._piece = piece;
        }

        private string _notation;
        public string Notation { get; }

        private Piece _piece;
        public Piece Piece { get; set; }
    }
}
