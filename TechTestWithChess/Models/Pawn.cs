using System;
using System.Collections.Generic;
using TechTestWithChess.Model.Interfaces;

namespace TechTestWithChess.Models
{
    public class PawnChessPiece : IChessPiece
    {
        public List<Move> FindValidMoves(int x, int y, string[,] phonePad, int movesCount, Move ParentMove = null)
        {
            if (movesCount >= 7)
            {
                return new List<Move>();
            }

            if (ParentMove == null)
                ParentMove = new Move();

            var result = new List<Move>();

            var diagonalLeftMoveResult = DiagLeftMove(x, y, phonePad);
            var straightMoveResult = StraightMove(x, y, phonePad);
            var diagonalRightMoveResult = DiagRightMove(x, y, phonePad);

            result.AddRange(diagonalLeftMoveResult);
            result.AddRange(straightMoveResult);
            result.AddRange(diagonalRightMoveResult);

            foreach (var nextMoveStarPos in result)
            {
                nextMoveStarPos.SubsequentMoves.AddRange(FindValidMoves(nextMoveStarPos.NewX, nextMoveStarPos.NewY, phonePad, movesCount + 1, nextMoveStarPos));
            }

            return result;
        }

        private List<Move> DiagLeftMove(int x, int y, string[,] phonePad)
        {
            var result = new List<Move>();
            int newY = y + 1;
            int newX = x - 1;
            bool isValid = true;

            if (newY > phonePad.GetLength(0) - 1 || newY < 0)
                isValid = false;

            if (newX > phonePad.GetLength(1) - 1 || newX < 0)
                isValid = false;

            if (isValid)
                result.Add(new Move() { OldX = x, OldY = y, NewX = newX, NewY = newY, Value = phonePad[newY, newX] });

            return result;
        }

        private List<Move> DiagRightMove(int x, int y, string[,] phonePad)
        {
            var result = new List<Move>();
            int newY = y + 1;
            int newX = x + 1;
            bool isValid = true;

            if (newY > phonePad.GetLength(0) - 1 || newY < 0)
                isValid = false;

            if (newX > phonePad.GetLength(1) - 1 || newX < 0)
                isValid = false;

            if (isValid)
                result.Add(new Move() { OldX = x, OldY = y, NewX = newX, NewY = newY, Value = phonePad[newY, newX] });

            return result;
        }

        private List<Move> StraightMove(int x, int y, string[,] phonePad)
        {
            var result = new List<Move>();
            int newY = y + 1;
            bool isValid = true;

            if (newY > phonePad.GetLength(0) -1 || newY < 0)
                isValid = false;

            if (isValid)
                result.Add(new Move() { OldX = x, OldY = y, NewX = x, NewY = newY, Value = phonePad[newY, x] });

            return result;
        }

    }
}
