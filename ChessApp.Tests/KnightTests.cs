using ChessApp.Models;
using ChessApp.Models.Pieces;

namespace ChessApp.Tests
{
    public class KnightTests
    {

        [Theory]
        [InlineData("b1", "c3", PlayerColor.White)]
        [InlineData("b1", "a3", PlayerColor.Black)]
        [InlineData("d4", "b5", PlayerColor.White)]
        [InlineData("d4", "b3", PlayerColor.Black)]
        [InlineData("f6", "e4", PlayerColor.White)]
        [InlineData("f6", "g4", PlayerColor.Black)]
        [InlineData("c3", "e2", PlayerColor.White)]
        [InlineData("c3", "e4", PlayerColor.Black)]
        public void KnightMoves_OnLs(string srcSquare, string dstSquare, PlayerColor color)
        {
            Knight knight = new Knight(color);

            bool result = knight.validMove(srcSquare, dstSquare);

            Assert.True(result);
        }

        [Theory]
        [InlineData("b1", "b3", PlayerColor.White)]
        [InlineData("b1", "d1", PlayerColor.Black)]
        [InlineData("d4", "f6", PlayerColor.White)]
        [InlineData("f4", "a2", PlayerColor.Black)]
        public void KnightDoesntMoves_OffLs(string srcSquare, string dstSquare, PlayerColor color)
        {
            Knight knight = new Knight(color);

            bool result = knight.validMove(srcSquare, dstSquare);

            Assert.False(result);
        }
    }
}
