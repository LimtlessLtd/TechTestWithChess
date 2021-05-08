using System;
using System.Collections.Generic;
using TechTestWithChess.Model.Interfaces;

namespace TechTestWithChess.Models
{
    public class BishopChessPiece : IChessPiece
    {
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

            var diagonalLeftUpMoveResult = DiagLeftUpMove(x, y, phonePad, new List<Move>());
            var diagonalLeftDownMoveResult = DiagLeftDownMove(x, y, phonePad, new List<Move>());
            var diagonalRightUpMoveResult = DiagRightUpMove(x, y, phonePad, new List<Move>());
            var diagonalRightDownMoveResult = DiagRightDownMove(x, y, phonePad, new List<Move>());

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

        private List<Move> DiagLeftUpMove(int x, int y, string[,] phonePad, List<Move> result, bool isValid = true)
        {
            int newY = y - 1;
            int newX = x - 1;

            if ((newY > phonePad.GetLength(0) - 1 || newY < 0) || (newX > phonePad.GetLength(1) - 1 || newX < 0))
                isValid = false;
            else
            {
                if (isValid)
                    result.AddRange(DiagLeftUpMove(newX, newY, phonePad, result, isValid));
            }

            if (isValid)
                result.Add(new Move() { OldX = x, OldY = y, NewX = newX, NewY = newY, Value = phonePad[newY, newX] });

            return result;
        }
        private List<Move> DiagLeftDownMove(int x, int y, string[,] phonePad, List<Move> result, bool isValid = true)
        {
            int newY = y + 1;
            int newX = x - 1;

            if ((newY > phonePad.GetLength(0) - 1 || newY < 0) || (newX > phonePad.GetLength(1) - 1 || newX < 0))
                isValid = false;
            else
            {
                if (isValid)
                    result.AddRange(DiagLeftDownMove(newX, newY, phonePad, result, isValid));
            }

            if (isValid)
                result.Add(new Move() { OldX = x, OldY = y, NewX = newX, NewY = newY, Value = phonePad[newY, newX] });

            return result;
        }
        private List<Move> DiagRightUpMove(int x, int y, string[,] phonePad, List<Move> result, bool isValid = true)
        {
            int newY = y - 1;
            int newX = x + 1;

            if ((newY > phonePad.GetLength(0) - 1 || newY < 0) || (newX > phonePad.GetLength(1) - 1 || newX < 0))
                isValid = false;
            else
            {
                if (isValid)
                    result.AddRange(DiagRightUpMove(newX, newY, phonePad, result, isValid));
            }

            if (isValid)
                result.Add(new Move() { OldX = x, OldY = y, NewX = newX, NewY = newY, Value = phonePad[newY, newX] });

            return result;
        }

        private List<Move> DiagRightDownMove(int x, int y, string[,] phonePad, List<Move> result, bool isValid = true)
        {
            int newY = y + 1;
            int newX = x + 1;

            if ((newY > phonePad.GetLength(0) - 1 || newY < 0) || (newX > phonePad.GetLength(1) - 1 || newX < 0))
                isValid = false;
            else
            {
                if (isValid)
                    result.AddRange(DiagRightDownMove(newX, newY, phonePad, result, isValid));
            }

            if (isValid)
                result.Add(new Move() { OldX = x, OldY = y, NewX = newX, NewY = newY, Value = phonePad[newY, newX] });

            return result;
        }

    }
}
