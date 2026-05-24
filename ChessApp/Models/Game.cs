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
            bool result = _board.movePiece(srcSquare, dstSquare, _whoseTurn);

            if (result)
            {
                if (_whoseTurn == PlayerColor.White)
                {
                    _whoseTurn = PlayerColor.Black;
                } else
                {
                    _whoseTurn = PlayerColor.White;
                }
            }

            return result;
        }

        public string[] getBoard()
        {
            string[] cols = ["a", "b", "c", "d", "e", "f", "g", "h"];
            string[] rows = ["8", "7", "6", "5", "4", "3", "2", "1"];

            string[] board = new string[cols.Length * rows.Length];

            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < cols.Length; j++)
                {
                    string notation = _board.BoardState[string.Concat(cols[j], rows[i])].Piece?.Notation ?? "";
                    board[i * 8 + j] = notation;
                }
            }

            return board;
        }
    }
}
