using System;
using System.Collections.Generic;
using System.Text;

namespace ChessApp.Models
{
    internal class Game
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

        public bool makeMove(int srcSquare, int dstSquare)
        {
            return false;
        }
    }
}
