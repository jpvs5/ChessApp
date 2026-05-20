using ChessApp.Models;
using ChessApp.Models.Pieces;

namespace ChessApp.Tests
{
    public class BishopTests
    {
        [Theory]
        [InlineData("c1", "a3", PlayerColor.White)]
        [InlineData("d7", "b5", PlayerColor.Black)]
        [InlineData("e5", "h8", PlayerColor.White)]
        [InlineData("f8", "g7", PlayerColor.Black)]
        public void BishopMoves_OnDiagonals(string srcSquare, string dstSquare, PlayerColor color)
        {
            Bishop bishop = new Bishop(color);

            bool result = bishop.validMove(srcSquare, dstSquare);

            Assert.True(result);
        }

        [Theory]
        [InlineData("c1", "a1", PlayerColor.White)]
        [InlineData("d7", "c5", PlayerColor.Black)]
        [InlineData("e5", "e8", PlayerColor.White)]
        [InlineData("f8", "g6", PlayerColor.Black)]
        public void BishopDoesnt_MoveOffDiagonals(string srcSquare, string dstSquare, PlayerColor color)
        {
            Bishop bishop = new Bishop(color);

            bool result = bishop.validMove(srcSquare, dstSquare);

            Assert.False(result);
        }
    }
}
