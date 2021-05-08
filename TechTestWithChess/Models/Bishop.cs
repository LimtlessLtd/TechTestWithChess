using System;
using System.Collections.Generic;
using TechTestWithChess.Model.Interfaces;
using TechTestWithChess.Services;

namespace TechTestWithChess.Models
{
    public class BishopChessPeice : IChessPeice
    {
        public MoveUtilities MovingUtils { get; set; } = new MoveUtilities();
        public List<Move> FindValidMoves(int x, int y, string[,] phonePad, int movesCount, Move ParentMove = null)
        {
            movesCount += 1;
            if (movesCount >= 7)
            {
                return new List<Move>();
            }

            if (ParentMove == null)
                ParentMove = new Move();

            var result = new List<Move>();

            var diagonalLeftUpMoveResult = MovingUtils.DiagLeftUpMoveInfinity(x, y, phonePad, new List<Move>());
            var diagonalLeftDownMoveResult = MovingUtils.DiagLeftDownMoveInfinity(x, y, phonePad, new List<Move>());
            var diagonalRightUpMoveResult = MovingUtils.DiagRightUpMoveInfinity(x, y, phonePad, new List<Move>());
            var diagonalRightDownMoveResult = MovingUtils.DiagRightDownMoveInfinity(x, y, phonePad, new List<Move>());

            result.AddRange(diagonalLeftUpMoveResult);
            result.AddRange(diagonalLeftDownMoveResult);
            result.AddRange(diagonalRightUpMoveResult);
            result.AddRange(diagonalRightDownMoveResult);

            foreach (var nextMoveStarPos in result)
            {
                nextMoveStarPos.SubsequentMoves.AddRange(FindValidMoves(nextMoveStarPos.NewX, nextMoveStarPos.NewY, phonePad, movesCount, nextMoveStarPos));
            }

            return result;
        }

    }
}
