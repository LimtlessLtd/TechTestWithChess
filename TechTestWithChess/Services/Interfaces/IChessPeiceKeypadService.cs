using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTestWithChess.Services.Interfaces
{
    interface IChessPeiceKeypadService
    {
        public List<string> SimulateMovementsForPeice(int PeiceToSim);
        public Tuple<bool, int> IsValidInput(string PeiceToSim);
    }
}
