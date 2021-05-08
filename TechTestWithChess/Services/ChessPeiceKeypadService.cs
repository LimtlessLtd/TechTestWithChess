using System;
using System.Collections.Generic;
using TechTestWithChess.Models;
using TechTestWithChess.Services.Interfaces;

namespace TechTestWithChess.Services
{
    public class ChessPeiceKeypadService : IChessPeiceKeypadService
    {
        public IChessPeiceService ChessPeiceService { get; set; } = new ChessPeiceService();
        public List<string> SimulateMovementsForPeice(int PeiceToSim)
        {
            var result = new List<string>();

            switch (PeiceToSim)
            {
                case 1:
                    result = ChessPeiceService.SimulateChessPeice(new PawnChessPeice());
                    break;
                case 2:
                    throw new NotImplementedException();
                    //result = ChessPeiceService.SimulateChessPeice(new Knight());
                    break;
                case 3:
                    result = ChessPeiceService.SimulateChessPeice(new BishopChessPeice());
                    break;
                case 4:
                    throw new NotImplementedException();
                    //result = ChessPeiceService.SimulateChessPeice(new Rook());
                    break;
                case 5:
                    throw new NotImplementedException();
                    //result = ChessPeiceService.SimulateChessPeice(new Queen());
                    break;
                case 6:
                    result = ChessPeiceService.SimulateChessPeice(new KingChessPeice());
                    break;
                default:
                    break;
            }

            return result;
        }

        public Tuple<bool, int> IsValidInput(string PeiceToSim)
        {
            bool blResult;
            int intPeiceToSim;
            blResult = int.TryParse(PeiceToSim, out intPeiceToSim);

            if (blResult && (intPeiceToSim >= 1 && intPeiceToSim <= 6))
                blResult = true;
            else
                blResult = false;

            return new Tuple<bool, int>(blResult, intPeiceToSim);
        }

        public List<string> GetDisplayInstructions()
        {
            var result = new List<string>();

            result.Add("Welcome to the Chess Peice Phone Dialing simulator");
            result.Add("-----------------------------------------------------------");
            result.Add("--How it works--");
            result.Add("Pick a chess peice with a defined set of moves available to it,");
            result.Add("the app will then loop through every starting position on the phonepad,");
            result.Add("and map out all possible moves up to 7 in a  row.");
            result.Add("");
            result.Add("We then flatten and loop through the map,");
            result.Add("looking for any results that meet the criteria set out in the question.");
            result.Add("-----------------------------------------------------------");
            result.Add("1 - Pawn");
            result.Add("2 - Knight -- NOT IMPLEMENTED!");
            result.Add("3 - Bishop");
            result.Add("4 - Rook/Castle -- NOT IMPLEMENTED!");
            result.Add("5 - Queen -- NOT IMPLEMENTED!");
            result.Add("6 - King");
            result.Add("Please enter Q if you wish to quit.");
            result.Add("Please enter the Peice that you wish to simulate:");

            return result;
        }
    }
}
