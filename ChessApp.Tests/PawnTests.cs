using ChessApp.Models;
using ChessApp.Models.Pieces;

namespace ChessApp.Tests
{
    public class PawnTests
    {
        [Fact]
        public void MoveWhitePawn_ForwardOne_ReturnTrue()
        {
            Pawn pawn = new Pawn(PlayerColor.White);

            bool result = pawn.validMove("a2", "a3");

            Assert.True(result);
        }

        [Fact]
        public void MoveBlackPawn_ForwardOne_ReturnTrue()
        {
            Pawn pawn = new Pawn(PlayerColor.Black);

            bool result = pawn.validMove("c7", "c6");

            Assert.True(result);
        }

        [Fact]
        public void MoveWhitePawn_BackwardOne_ReturnFalse()
        {
            Pawn pawn = new Pawn(PlayerColor.White);

            bool result = pawn.validMove("d4", "d3");

            Assert.False(result);
        }

        [Fact]
        public void MoveBlackPawn_BackwardOne_ReturnFalse()
        {
            Pawn pawn = new Pawn(PlayerColor.Black);

            bool result = pawn.validMove("g6", "g7");

            Assert.False(result);
        }

        [Fact]
        public void MoveWhitePawn_DoubleStepValid()
        {
            Pawn pawn = new Pawn(PlayerColor.White);

            bool result = pawn.validMove("f2", "f4");

            Assert.True(result);
        }

        [Fact]
        public void MoveBlackPawn_DoubleStepValid()
        {
            Pawn pawn = new Pawn(PlayerColor.Black);

            bool result = pawn.validMove("c7", "c5");

            Assert.True(result);
        }

        [Fact]
        public void MoveWhitePawn_DoubleStepInalid()
        {
            Pawn pawn = new Pawn(PlayerColor.White);
            pawn.CanDoubleStep = false;

            bool result = pawn.validMove("a3", "a5");

            Assert.False(result);
        }

        [Fact]
        public void MoveBlackPawn_DoubleStepInalid()
        {
            Pawn pawn = new Pawn(PlayerColor.Black);
            pawn.CanDoubleStep = false;

            bool result = pawn.validMove("d6", "d4");

            Assert.False(result);
        }

        [Theory]
        [InlineData("b4", "c5", PlayerColor.White)]
        [InlineData("f3", "e4", PlayerColor.White)]
        [InlineData("h6", "g5", PlayerColor.Black)]
        [InlineData("d7", "c6", PlayerColor.Black)]
        public void MovePawn_DiagonalCapture_Valid(string srcSquare, string dstSquare, PlayerColor color)
        {
            Pawn pawn = new Pawn(color);

            bool result = pawn.validMove(srcSquare, dstSquare);

            Assert.True(result);
        }
    }
}
