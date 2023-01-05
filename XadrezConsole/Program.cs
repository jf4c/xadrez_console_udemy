using BoardLayer;
using GameLayer;
using BoardLayer.Enum;

namespace XadrezConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);

            board.PutPiece(new Torre(board, Color.Black), new Position(0, 0));
            board.PutPiece(new Torre(board, Color.Black), new Position(1, 3));
            board.PutPiece(new Rei(board, Color.Black), new Position(2, 4));


            Screen.PrintBoard(board);

        }
    }
}