using System;
using System.Collections.Generic;
using TechTestWithChess.Models;
using TechTestWithChess.Services.Interfaces;

namespace TechTestWithChess.Services
{
    public class ChessPieceKeypadService : IChessPieceKeypadService
    {
        public IChessPieceService ChessPieceService { get; set; } = new ChessPieceService();
        public List<string> SimulateMovementsForPiece(int PieceToSim)
        {
            var result = new List<string>();

            switch (PieceToSim)
            {
                case 1:
                    result = ChessPieceService.SimulateChessPiece(new PawnChessPiece());
                    break;
                case 2:
                    throw new NotImplementedException();
                    //result = ChessPieceService.SimulateChessPiece(new Knight());
                    break;
                case 3:
                    result = ChessPieceService.SimulateChessPiece(new BishopChessPiece());
                    break;
                case 4:
                    throw new NotImplementedException();
                    //result = ChessPieceService.SimulateChessPiece(new Rook());
                    break;
                case 5:
                    throw new NotImplementedException();
                    //result = ChessPieceService.SimulateChessPiece(new Queen());
                    break;
                case 6:
                    result = ChessPieceService.SimulateChessPiece(new KingChessPiece());
                    break;
                default:
                    break;
            }

            return result;
        }

        public Tuple<bool, int> IsValidInput(string PieceToSim)
        {
            bool blResult;
            int intPieceToSim;
            blResult = int.TryParse(PieceToSim, out intPieceToSim);

            if (blResult && (intPieceToSim >= 1 && intPieceToSim <= 6))
                blResult = true;
            else
                blResult = false;

            return new Tuple<bool, int>(blResult, intPieceToSim);
        }

        public List<string> GetDisplayInstructions()
        {
            var result = new List<string>();

            result.Add("Welcome to the Chess Piece Phone Dialing simulator");
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
            result.Add("Please enter the Piece that you wish to simulate:");

            return result;
        }
    }
}
