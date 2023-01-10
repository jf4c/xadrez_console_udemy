
using BoardLayer;
using BoardLayer.Enum;
using GameLayer;
using System.Text.RegularExpressions;

namespace XadrezConsole
{
    internal class Screen
    {

        public static void PrintMatch(ChessMatch match) 
        {
            Screen.PrintBoard(match.Board);
            Console.WriteLine();
            PrintPieceCaptured(match);
            Console.WriteLine();
            Console.WriteLine("Turno: " + match.Turn);
            Console.WriteLine("Aguardando Jogada: " + match.CurrentPlayer);
            if (match.Check)
            {
                Console.WriteLine("XEQUE!");
            }
        }

        public static void PrintPieceCaptured(ChessMatch match)
        {
            Console.WriteLine("peças Capturadas:");
            Console.Write("Brancas");
            PrintSet(match.CapturedPieces(Color.White));
            Console.WriteLine();
            Console.Write("Pretas");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintSet(match.CapturedPieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();    
        }

        public static void PrintSet(HashSet<Piece> set)
        {
            Console.Write("[");
            foreach (Piece p  in set)
            {
                Console.Write(p + " ");

            }
            Console.Write("]");

        }


        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Line; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Column; j++)
                {
                    PrintPiece(board.Piece(i, j));
                }

                Console.WriteLine();
            }
            Console.WriteLine("  a  b  c  d  e  f  g  h");
        }



        public static void PrintBoard(Board board, bool[,] possiblePositions)
        {
            ConsoleColor originBackgrund = Console.BackgroundColor;
            ConsoleColor alteredBackgrund = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Line; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Column; j++)
                {
                    if (possiblePositions[i, j])
                    {
                        Console.BackgroundColor = alteredBackgrund; 
                    }
                    else
                    {
                        Console.BackgroundColor = originBackgrund;
                    }

                    PrintPiece(board.Piece(i, j));
                    Console.BackgroundColor = originBackgrund;
                }

                Console.WriteLine();
            }
            Console.WriteLine("  a  b  c  d  e  f  g  h");
            Console.BackgroundColor = originBackgrund;
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

            if (piece == null)
            {
                Console.Write("-  ");
            }
            else
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
                Console.Write("  ");
            }
            
        }

    }
}
