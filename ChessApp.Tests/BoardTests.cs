using ChessApp.Models;
using ChessApp.Models.Pieces;

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
    }
}
