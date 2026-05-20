using ChessApp.Models;
using ChessApp.Models.Pieces;

namespace ChessApp.Tests
{
    public class RookTests
    {
        [Theory]
        [InlineData("a1", "a6", PlayerColor.White)]
        [InlineData("d6", "d3", PlayerColor.Black)]
        [InlineData("c4", "a4", PlayerColor.White)]
        [InlineData("g5", "h5", PlayerColor.Black)]
        public void RooksMove_OnRowsAndCols(string srcSquare, string dstSquare, PlayerColor color)
        {
            Rook rook = new Rook(color);

            bool result = rook.validMove(srcSquare, dstSquare);

            Assert.True(result);
        }

        [Theory]
        [InlineData("a1", "b2", PlayerColor.White)]
        [InlineData("d6", "c7", PlayerColor.Black)]
        [InlineData("c4", "b3", PlayerColor.White)]
        [InlineData("g5", "h4", PlayerColor.Black)]
        public void RooksDontMove_OffRowsAndCols(string srcSquare, string dstSquare, PlayerColor color)
        {
            Rook rook = new Rook(color);

            bool result = rook.validMove(srcSquare, dstSquare);

            Assert.False(result);
        }
    }
}
