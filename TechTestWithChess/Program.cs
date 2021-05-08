using System;
using TechTestWithChess.Services;
using TechTestWithChess.Services.Interfaces;

namespace TechTestWithChess
{
    class Program
    {
        static ChessPieceKeypadService ChessPieceKeypadService = new ChessPieceKeypadService();
        static void Main(string[] args)
        {
            string PieceToSimulate;

            do
            {
                ChessPieceKeypadService.GetDisplayInstructions().ForEach(x => Console.WriteLine(x));
                PieceToSimulate = Console.ReadLine();

                var result = ChessPieceKeypadService.IsValidInput(PieceToSimulate);

                if (result.Item1)
                {
                    var response = ChessPieceKeypadService.SimulateMovementsForPiece(result.Item2);

                    response.ForEach(x => Console.WriteLine(x));
                }
                else if(PieceToSimulate.ToLower() != "q")
                    Console.WriteLine("Incorrect input, please try again; or enter Q to quit.");

            } while (PieceToSimulate.ToLower() != "q");

            Environment.Exit(0);
        }

    }
}
