
using BoardLayer;
using BoardLayer.Enum;
using GameLayer;

namespace XadrezConsole
{
    internal class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Line; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Column; j++)
                {
                    if (board.Piece(i,j) == null)
                    {
                        Console.Write("-  ");
                    }
                    else 
                    {
                        PrintPiece(board.Piece(i, j));
                        Console.Write("  ");

                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a  b  c  d  e  f  g  h");
        }


        public static PositionChess ReadPositionChess()
        {
            string s = Console.ReadLine();
            char colunm = s[0];
            int line = int.Parse(s[1] + "");
            return new PositionChess(colunm, line);
        }


        public static void PrintPiece(Piece piece)
        {
            if (piece.Color == Color.White)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }

    }
}
