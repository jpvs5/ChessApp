using ChessApp.Models;
using ChessApp.Models.Pieces;

namespace ChessApp.Tests
{
    public class KingTests
    {
        [Theory]
        [InlineData("e1", "e2", PlayerColor.White)]
        [InlineData("d6", "e7", PlayerColor.Black)]
        [InlineData("c4", "d4", PlayerColor.White)]
        [InlineData("g5", "h4", PlayerColor.Black)]
        [InlineData("f2", "f1", PlayerColor.White)]
        [InlineData("b3", "a2", PlayerColor.Black)]
        [InlineData("c4", "b4", PlayerColor.White)]
        [InlineData("g5", "f6", PlayerColor.Black)]
        public void KingsMoveOne_OnDiagonalsRowsAndCols(string srcSquare, string dstSquare, PlayerColor color)
        {
            King king = new King(color);

            bool result = king.validMove(srcSquare, dstSquare);

            Assert.True(result);
        }

        [Theory]
        [InlineData("a1", "c2", PlayerColor.White)]
        [InlineData("d6", "c4", PlayerColor.Black)]
        [InlineData("c4", "b2", PlayerColor.White)]
        [InlineData("g5", "e4", PlayerColor.Black)]
        [InlineData("d3", "d3", PlayerColor.White)]
        public void KingsDontMove_MoreThanOne(string srcSquare, string dstSquare, PlayerColor color)
        {
            King king = new King(color);

            bool result = king.validMove(srcSquare, dstSquare);

            Assert.False(result);
        }
    }
}