using System;
using System.Collections.Generic;
using TechTestWithChess.Model.Interfaces;
using TechTestWithChess.Services;

namespace TechTestWithChess.Models
{
    public class PawnChessPeice : IChessPeice
    {
        public MoveUtilities MovingUtils { get; set; } = new MoveUtilities();
        public List<Move> FindValidMoves(int x, int y, string[,] phonePad, int movesCount, Move ParentMove = null)
        {
            if (movesCount >= 7)
            {
                return new List<Move>();
            }

            if (ParentMove == null)
                ParentMove = new Move();

            var result = new List<Move>();

            var diagonalLeftMoveResult = MovingUtils.DiagLeftDownMove(x, y, phonePad);
            var straightMoveResult = MovingUtils.StraightDownMove(x, y, phonePad);
            var diagonalRightMoveResult = MovingUtils.DiagRightDownMove(x, y, phonePad);

            result.AddRange(diagonalLeftMoveResult);
            result.AddRange(straightMoveResult);
            result.AddRange(diagonalRightMoveResult);

            foreach (var nextMoveStarPos in result)
            {
                nextMoveStarPos.SubsequentMoves.AddRange(FindValidMoves(nextMoveStarPos.NewX, nextMoveStarPos.NewY, phonePad, movesCount + 1, nextMoveStarPos));
            }

            return result;
        }
    }
}
