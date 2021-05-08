using System;
using System.Collections.Generic;
using TechTestWithChess.Models;

namespace TechTestWithChess.Services.Interfaces
{
    interface IMoveUtilities
    {
        public List<Move> DiagLeftUpMove(int x, int y, string[,] phonePad);
        public List<Move> DiagLeftDownMove(int x, int y, string[,] phonePad);
        public List<Move> DiagRightUpMove(int x, int y, string[,] phonePad);
        public List<Move> DiagRightDownMove(int x, int y, string[,] phonePad);
        public List<Move> StraightDownMove(int x, int y, string[,] phonePad);
        public List<Move> StraightUpMove(int x, int y, string[,] phonePad);
        public List<Move> StraightLeftMove(int x, int y, string[,] phonePad);
        public List<Move> StraightRightMove(int x, int y, string[,] phonePad);
        public List<Move> DiagLeftUpMoveInfinity(int x, int y, string[,] phonePad, List<Move> result, bool isValid = true);
        public List<Move> DiagLeftDownMoveInfinity(int x, int y, string[,] phonePad, List<Move> result, bool isValid = true);
        public List<Move> DiagRightUpMoveInfinity(int x, int y, string[,] phonePad, List<Move> result, bool isValid = true);
        public List<Move> DiagRightDownMoveInfinity(int x, int y, string[,] phonePad, List<Move> result, bool isValid = true);

    }
}
