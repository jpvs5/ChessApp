using System;
using System.Collections.Generic;
using System.Text;

namespace ChessApp.Models
{
    internal class Board
    {
        public Board()
        {
        }

        public Dictionary<string, Square> BoardState { get; }

        public bool movePiece(string square, PlayerColor color)
        {
            return false;
        }
    }
}
