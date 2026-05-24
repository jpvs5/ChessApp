using ChessApp.Models.Pieces;
using System;
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

        public static int colDist(string srcSquare,  string dstSquare)
        {
            return dstSquare[0] - srcSquare[0];
        }

        public static int rowDist(string srcSquare, string dstSquare)
        {
            return (int)char.GetNumericValue(dstSquare[1]) - (int)char.GetNumericValue(srcSquare[1]);
        }

        public Dictionary<string, Square> BoardState { get; }

        private bool validRow(string square)
        {
            int squareRow = (int)char.GetNumericValue(square[1]);

            if (squareRow < 1 || squareRow > 8)
            {
                return false;
            }

            return true;
        }

        private bool validCol(string square)
        {
            char[] validCols = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h'];

            if (!validCols.Contains(square[0])) {
                return false;
            }

            return true;
        }

        private bool validSquare(string square)
        {
            return square.Length == 2 && validRow(square) && validCol(square);
        }

        private string incrementRow(string square)
        {
            char row = square[1];
            row++;

            return string.Concat(square[0], row);
        }

        private string decrementRow(string square)
        {
            char row = square[1];
            row--;

            return string.Concat(square[0], row);
        }

        private string incrementCol(string square)
        {
            char col = square[0];
            col++;

            return string.Concat(col, square[1]);
        }

        private string decrementCol(string square)
        {
            char col = square[0];
            col--;

            return string.Concat(col, square[1]);
        }

        private bool checkSquares(string square, int distance, Func<string, string> squareMod)
        {
            while (distance > 1)
            {
                square = squareMod(square);
                distance--;

                if (BoardState[square].Piece != null)
                {
                    return true;
                }
            }

            return false;

        }

        private bool checkSquares(string square, int distance, Func<string, string> squareColMod, Func<string, string> squareRowMod)
        {
            while (distance > 1)
            {
                square = squareColMod(square);
                square = squareRowMod(square);
                distance--;

                if (BoardState[square].Piece != null)
                {
                    return true;
                }
            }

            return false;

        }

        public bool isPathObstructed(string srcSquare, string dstSquare)
        {
            int rowDist = Board.rowDist(srcSquare, dstSquare);
            int colDist = Board.colDist(srcSquare, dstSquare);

            int distance = 0;
            Func<string, string> modFunc;

            switch (colDist)
            {
                case < 0:
                    distance = Math.Abs(colDist);
                    modFunc = square => decrementCol(square);
                    break;
                case > 0:
                    distance = Math.Abs(colDist);
                    modFunc = square => incrementCol(square);
                    break;
                case 0:
                    modFunc = square => square;
                    break;
            }

            switch (rowDist)
            {
                case < 0:
                    distance = Math.Abs(rowDist);
                    return checkSquares(srcSquare, distance, modFunc, decrementRow);
                case > 0:
                    distance = Math.Abs(rowDist);
                    return checkSquares(srcSquare, distance, modFunc, incrementRow);
                default:
                    return checkSquares(srcSquare, distance, modFunc);
            }
        }

        public bool isValidCastle(string srcSquare, string dstSquare)
        {
            if (BoardState[srcSquare].Piece.Notation != "K")
            {
                return false;
            }

            King king = (King)BoardState[srcSquare].Piece;
            Piece rook;

            if (!king.CanCastle)
            {
                return false;
            }

            switch (srcSquare)
            {
                case "e1":
                    switch (dstSquare)
                    {
                        case "c1":
                            rook = BoardState["a1"].Piece;
                            return (rook != null && rook.Notation == "R" && ((Rook)rook).CanCastle);
                        case "g1":
                            rook = BoardState["h1"].Piece;
                            return (rook != null && rook.Notation == "R" && ((Rook)rook).CanCastle);
                        default:
                            return false;
                    }
                case "e8":
                    switch (dstSquare)
                    {
                        case "c8":
                            rook = BoardState["a8"].Piece;
                            return (rook != null && rook.Notation == "R" && ((Rook)rook).CanCastle);
                        case "g8":
                            rook = BoardState["h8"].Piece;
                            return (rook != null && rook.Notation == "R" && ((Rook)rook).CanCastle);
                        default:
                            return false;
                    }
                default:
                    return false;
            }
        }

        public bool movePiece(string srcSquare, string dstSquare, PlayerColor color)
        {
            if (!validSquare(srcSquare) || !validSquare(dstSquare))
            {
                return false;
            }

            Piece piece = BoardState[srcSquare].Piece;

            if (piece == null)
            {
                return false;
            }

            if (piece.PieceColor != color)
            {
                return false;
            }

            if (BoardState[dstSquare].Piece != null && BoardState[dstSquare].Piece.PieceColor == color)
            {
                return false;
            }

            if (piece.Notation != "N" && isPathObstructed(srcSquare, dstSquare)) {
                return false;
            }

            if (isValidCastle(srcSquare, dstSquare))
            {
                return true;
            }

            BoardState[dstSquare].Piece = piece;
            BoardState[srcSquare].Piece = null;

            return true;
        }
    }
}
