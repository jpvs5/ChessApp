namespace ChessApp.Models
{
    public class Game
    {
        public Game()
        {
            this._whoseTurn = PlayerColor.White;
            this._isWon = false;
            this._board = new Board();
        }

        private PlayerColor _whoseTurn;

        private bool _isWon;

        private Board _board;

        public bool makeMove(string srcSquare, string dstSquare)
        {
            return false;
        }
    }
}
