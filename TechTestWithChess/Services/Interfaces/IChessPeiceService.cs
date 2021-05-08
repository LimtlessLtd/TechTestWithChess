using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTestWithChess.Model.Interfaces;

namespace TechTestWithChess.Services.Interfaces
{
    public interface IChessPieceService
    {
        public List<string> SimulateChessPiece(IChessPiece chessPiece);
    }
}
