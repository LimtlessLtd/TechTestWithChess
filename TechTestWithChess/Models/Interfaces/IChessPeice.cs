using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTestWithChess.Models;

namespace TechTestWithChess.Model.Interfaces
{
    public interface IChessPeice
    {
        public List<Move> FindValidMoves(int x, int y, string[,] phonePad, int movesCount, Move ParentMove = null);
    }
}
