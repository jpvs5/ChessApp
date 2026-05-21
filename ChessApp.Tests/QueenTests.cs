using ChessApp.Models;
using ChessApp.Models.Pieces;

namespace ChessApp.Tests
{
    public class QueenTests
    {
        [Theory]
        [InlineData("c1", "a3", PlayerColor.White)]
        [InlineData("d7", "b5", PlayerColor.Black)]
        [InlineData("e5", "h8", PlayerColor.White)]
        [InlineData("f8", "g7", PlayerColor.Black)]
        public void QueenMoves_OnDiagonals(string srcSquare, string dstSquare, PlayerColor color)
        {
            Queen queen = new Queen(color);

            bool result = queen.validMove(srcSquare, dstSquare);

            Assert.True(result);
        }

        [Theory]
        [InlineData("a1", "a6", PlayerColor.White)]
        [InlineData("d6", "d3", PlayerColor.Black)]
        [InlineData("c4", "a4", PlayerColor.White)]
        [InlineData("g5", "h5", PlayerColor.Black)]
        public void QueensMove_OnRowsAndCols(string srcSquare, string dstSquare, PlayerColor color)
        {
            Queen queen = new Queen(color);

            bool result = queen.validMove(srcSquare, dstSquare);

            Assert.True(result);
        }

        [Theory]
        [InlineData("a1", "c2", PlayerColor.White)]
        [InlineData("d6", "c4", PlayerColor.Black)]
        [InlineData("c4", "b2", PlayerColor.White)]
        [InlineData("g5", "e4", PlayerColor.Black)]
        [InlineData("d3", "d3", PlayerColor.White)]
        public void QueensDontMove_OffDiagonalsRowsAndCols(string srcSquare, string dstSquare, PlayerColor color)
        {
            Queen queen = new Queen(color);

            bool result = queen.validMove(srcSquare, dstSquare);

            Assert.False(result);
        }
    }
}
