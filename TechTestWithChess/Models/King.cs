using System;
using System.Collections.Generic;
using TechTestWithChess.Model.Interfaces;
using TechTestWithChess.Services;

namespace TechTestWithChess.Models
{
    public class KingChessPeice : IChessPeice
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

            var diagonalLeftUpMoveResult = MovingUtils.DiagLeftUpMove(x, y, phonePad);
            var diagonalLeftDownMoveResult = MovingUtils.DiagLeftDownMove(x, y, phonePad);
            var diagonalRightUpMoveResult = MovingUtils.DiagRightUpMove(x, y, phonePad);
            var diagonalRightDownMoveResult = MovingUtils.DiagRightDownMove(x, y, phonePad);

            var straightUpMoveResult = MovingUtils.StraightUpMove(x, y, phonePad);
            var straightDownMoveResult = MovingUtils.StraightDownMove(x, y, phonePad);
            var straightLeftMoveResult = MovingUtils.StraightLeftMove(x, y, phonePad);
            var straightRightMoveResult = MovingUtils.StraightRightMove(x, y, phonePad);

            result.AddRange(diagonalLeftUpMoveResult);
            result.AddRange(diagonalLeftDownMoveResult);
            result.AddRange(diagonalRightUpMoveResult);
            result.AddRange(diagonalRightDownMoveResult);

            result.AddRange(straightUpMoveResult);
            result.AddRange(straightDownMoveResult);
            result.AddRange(straightLeftMoveResult);
            result.AddRange(straightRightMoveResult);

            foreach (var nextMoveStarPos in result)
            {
                nextMoveStarPos.SubsequentMoves.AddRange(FindValidMoves(nextMoveStarPos.NewX, nextMoveStarPos.NewY, phonePad, movesCount, nextMoveStarPos));
            }

            return result;
        }
    }
}
