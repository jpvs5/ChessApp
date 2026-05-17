using ChessApp.Models.Pieces;
using System.Collections.Generic;

namespace ChessApp.Models
{
    public class Board
    {
        public Board()
        {
            BoardState = new Dictionary<string, Square>();
            initBoard();
        }

        private void initBoard()
        {
            string[] columns = ["a", "b", "c", "d", "e", "f", "g", "h"];

            foreach (string column in columns)
            {
                for (int i = 1; i <= 8; i++)
                {
                    string notation = $"{column}{i}";
                    BoardState.Add(notation, new Square(notation, null));
                }
            }

            Piece[] whiteBackLine = createBackLine(PlayerColor.White);
            Piece[] blackBackLine = createBackLine(PlayerColor.Black);

            for (int i = 0; i < columns.Length; i++)
            {
                BoardState[$"{columns[i]}2"].Piece = new Pawn(PlayerColor.White);
                BoardState[$"{columns[i]}7"].Piece = new Pawn(PlayerColor.Black);

                BoardState[$"{columns[i]}1"].Piece = whiteBackLine[i];
                BoardState[$"{columns[i]}8"].Piece = blackBackLine[i];
            }
        }

        private Piece[] createBackLine(PlayerColor playerColor)
        {
            return [new Rook(playerColor),
                    new Knight(playerColor),
                    new Bishop(playerColor),
                    new Queen(playerColor),
                    new King(playerColor),
                    new Bishop(playerColor),
                    new Knight(playerColor),
                    new Rook(playerColor)];
        }

        public Dictionary<string, Square> BoardState { get; }

        public bool movePiece(string srcSquare, string dstSquare, PlayerColor color)
        {
            return false;
        }
    }
}
