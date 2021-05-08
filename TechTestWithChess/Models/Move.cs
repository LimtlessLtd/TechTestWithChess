using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTestWithChess.Models
{
    public class Move
    {
        public int OldX { get; set; }
        public int OldY { get; set; }
        public int NewX { get; set; }
        public int NewY { get; set; }
        public string Value { get; set; }
        public List<Move> SubsequentMoves { get; set; } = new List<Move>();
    }
}
