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
                    try
                    {
                        Console.Clear();
                        Screen.PrintBoard(match.Board);
                        Console.WriteLine();
                        Console.WriteLine("Turno: " + match.Turn);
                        Console.WriteLine("Aguardando Jogada: " + match.CurrentPlayer);



                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Position origin = Screen.ReadPositionChess().ToPosition();
                        match.ValidateOriginPosition(origin);

                        bool[,] PossiblePositions = match.Board.Piece(origin).PossibleMoves();


                        Console.Clear();
                        Screen.PrintBoard(match.Board, PossiblePositions);



                        Console.Write("Destino: ");
                        Position destiny = Screen.ReadPositionChess().ToPosition();
                        match.ValidateDestinyPosition(origin,destiny);
                        match.PerformsMove(origin, destiny);

                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                    
                }
              

            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }


        }
    }
}