using System;
using TechTestWithChess.Services;
using TechTestWithChess.Services.Interfaces;

namespace TechTestWithChess
{
    class Program
    {
        static ChessPeiceKeypadService ChessPeiceKeypadService = new ChessPeiceKeypadService();
        static void Main(string[] args)
        {
            string PeiceToSimulate;

            do
            {
                ChessPeiceKeypadService.GetDisplayInstructions().ForEach(x => Console.WriteLine(x));
                PeiceToSimulate = Console.ReadLine();

                var result = ChessPeiceKeypadService.IsValidInput(PeiceToSimulate);

                if (result.Item1)
                {
                    var response = ChessPeiceKeypadService.SimulateMovementsForPeice(result.Item2);

                    response.ForEach(x => Console.WriteLine(x));
                }
                else if(PeiceToSimulate.ToLower() != "q")
                    Console.WriteLine("Incorrect input, please try again; or enter Q to quit.");

            } while (PeiceToSimulate.ToLower() != "q");

            Environment.Exit(0);
        }

    }
}
