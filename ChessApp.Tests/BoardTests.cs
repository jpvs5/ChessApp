using ChessApp.Models;
using ChessApp.Models.Pieces;
using SkiaSharp;

namespace ChessApp.Tests
{
    public class BoardTests
    {
        [Fact]
        public void InitBoardTest()
        {
            Board board = new Board();

            string[] columns = ["a", "b", "c", "d", "e", "f", "g", "h"];

            Piece[] backline = [new Rook(PlayerColor.White),
                                        new Knight(PlayerColor.White),
                                        new Bishop(PlayerColor.White),
                                        new Queen(PlayerColor.White),
                                        new King(PlayerColor.White),
                                        new Bishop(PlayerColor.White),
                                        new Knight(PlayerColor.White),
                                        new Rook(PlayerColor.White)];

            for (int i = 0; i < columns.Length; i++)
            {
                Piece whitePawn = board.BoardState[$"{columns[i]}2"].Piece;
                Assert.IsType<Pawn>(whitePawn);
                Assert.Equal(PlayerColor.White, whitePawn.PieceColor);

                Piece blackPawn = board.BoardState[$"{columns[i]}7"].Piece;
                Assert.IsType<Pawn>(blackPawn);
                Assert.Equal(PlayerColor.Black, blackPawn.PieceColor);

                Type type = backline[i].GetType();
                Assert.IsType(type, board.BoardState[$"{columns[i]}1"].Piece);
                Assert.IsType(type, board.BoardState[$"{columns[i]}8"].Piece);

                Assert.Equal(PlayerColor.White, board.BoardState[$"{columns[i]}1"].Piece.PieceColor);
                Assert.Equal(PlayerColor.Black, board.BoardState[$"{columns[i]}8"].Piece.PieceColor);

                Assert.Null(board.BoardState[$"{columns[i]}3"].Piece);
                Assert.Null(board.BoardState[$"{columns[i]}4"].Piece);
                Assert.Null(board.BoardState[$"{columns[i]}5"].Piece);
                Assert.Null(board.BoardState[$"{columns[i]}6"].Piece);
            }
        }

        [Theory]
        [InlineData("b3", "c4", PlayerColor.White)]
        [InlineData("h2", "h3", PlayerColor.Black)]
        [InlineData("e1", "e2", PlayerColor.White)]
        public void MovePieceTest_ReturnFalse(string srcSquare, string dstSquare, PlayerColor playerColor)
        {
            Board board = new Board();
            
            Assert.False(board.movePiece(srcSquare, dstSquare, playerColor));
        }

        [Theory]
        [InlineData("c2", "c3", PlayerColor.White)]
        [InlineData("e7", "e5", PlayerColor.Black)]
        [InlineData("b1", "c3", PlayerColor.White)]
        public void MovePieceTest_ReturnTrue(string srcSquare, string dstSquare, PlayerColor playerColor)
        {
            Board board = new Board();

            Assert.True(board.movePiece(srcSquare, dstSquare, playerColor));
        }

        [Theory]
        [InlineData("c9", "c3", PlayerColor.White)]
        [InlineData("e7", "e0", PlayerColor.Black)]
        [InlineData("b1", "c10", PlayerColor.White)]
        public void MovePiece_InvalidSquare_ReturnFalse(string srcSquare, string dstSquare, PlayerColor playerColor)
        {
            Board board = new Board();

            Assert.False(board.movePiece(srcSquare, dstSquare, playerColor));
        }

        [Fact]
        public void ColDistTest()
        {
            Assert.Equal(1, Board.colDist("a2", "b2"));
            Assert.Equal(0, Board.colDist("g2", "g7"));
            Assert.Equal(3, Board.colDist("c2", "f5"));
            Assert.Equal(-2, Board.colDist("e1", "c3"));
        }

        [Fact]
        public void RowDistTest()
        {
            Assert.Equal(0, Board.rowDist("a2", "b2"));
            Assert.Equal(5, Board.rowDist("g2", "g7"));
            Assert.Equal(3, Board.rowDist("c2", "f5"));
            Assert.Equal(-2, Board.rowDist("e3", "c1"));
        }

        [Theory]
        [InlineData("a1", "a4")]
        [InlineData("c8", "c6")]
        [InlineData("d1", "g1")]
        [InlineData("g1", "d1")]
        [InlineData("c1", "e3")]
        [InlineData("f1", "d3")]
        [InlineData("c8", "a6")]
        [InlineData("f8", "h6")]
        public void IsPathObstructed_ReturnTrue(string srcSquare, string dstSquare)
        {
            Board board = new Board();

            bool result = board.isPathObstructed(srcSquare, dstSquare);

            Assert.True(result);
        }

        [Theory]
        [InlineData("b2", "b4")]
        [InlineData("d4", "f6")]
        [InlineData("g6", "d6")]
        public void IsPathObstructed_ReturnFalse(string srcSquare, string dstSquare)
        {
            Board board = new Board();

            bool result = board.isPathObstructed(srcSquare, dstSquare);

            Assert.False(result);
        }

        [Theory]
        [InlineData("e1", "g1")]
        [InlineData("e1", "c1")]
        [InlineData("e8", "c8")]
        [InlineData("e8", "g8")]
        public void IsValidCastle_ReturnTrue(string srcSquare, string dstSquare)
        {
            Board board = new Board();

            bool result = board.isValidCastle(srcSquare, dstSquare);

            Assert.True(result);
        }

        [Theory]
        [InlineData("e1", "h1")]
        [InlineData("e1", "b1")]
        [InlineData("e8", "b8")]
        [InlineData("e8", "h8")]
        public void IsValidCastle_WrongSquare_ReturnFalse(string srcSquare, string dstSquare)
        {
            Board board = new Board();

            bool result = board.isValidCastle(srcSquare, dstSquare);

            Assert.False(result);
        }

        //[Theory]
        //[InlineData("e1", "h1")]
        //[InlineData("e1", "a1")]
        //[InlineData("e8", "a8")]
        //[InlineData("e8", "g8")]
        //public void IsValidCastle_PieceMoved_ReturnFalse(string srcSquare, string dstSquare)
        //{
        //    Board board = new Board();

        //    bool result = board.isValidCastle(srcSquare, dstSquare);

        //    Assert.False(result);
        //}
    }
}
