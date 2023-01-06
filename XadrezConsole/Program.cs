using BoardLayer;
using GameLayer;
using BoardLayer.Enum;

namespace XadrezConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch match = new ChessMatch();
                while (!match.Finishing)
                {
                    Console.Clear();
                    Screen.PrintBoard(match.Board);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Position origin = Screen.ReadPositionChess().ToPosition();

                    Console.Write("Destino: ");
                    Position destiny = Screen.ReadPositionChess().ToPosition();

                    match.ExecuteMovement(origin, destiny);
                }
              

            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}