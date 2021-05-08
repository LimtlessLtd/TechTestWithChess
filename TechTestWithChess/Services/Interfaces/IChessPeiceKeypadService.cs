using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTestWithChess.Services.Interfaces
{
    interface IChessPieceKeypadService
    {
        public List<string> SimulateMovementsForPiece(int PieceToSim);
        public Tuple<bool, int> IsValidInput(string PieceToSim);
    }
}
