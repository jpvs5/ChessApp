using ChessApp.Models;
using ChessApp.Models.Pieces;
using SkiaSharp;

namespace ChessApp.Tests
{
    public class PawnTests
    {
        [Fact]
        public void MovePawn_ForwardOne_ReturnTrue()
        {
            Pawn pawn = new Pawn(PlayerColor.White);

            bool result = pawn.validMove("a2", "a3");

            Assert.True(result);
        }
    }
}
