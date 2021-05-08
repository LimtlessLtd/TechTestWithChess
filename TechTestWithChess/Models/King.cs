using System;
using System.Collections.Generic;
using TechTestWithChess.Model.Interfaces;

namespace TechTestWithChess.Models
{
    public class KingChessPiece : IChessPiece
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

            var diagonalLeftUpMoveResult = DiagLeftUpMove(x, y, phonePad);
            var diagonalLeftDownMoveResult = DiagLeftDownMove(x, y, phonePad);
            var diagonalRightUpMoveResult = DiagRightUpMove(x, y, phonePad);
            var diagonalRightDownMoveResult = DiagRightDownMove(x, y, phonePad);

            var straightUpMoveResult = StraightUpMove(x, y, phonePad);
            var straightDownMoveResult = StraightDownMove(x, y, phonePad);
            var straightLeftMoveResult = StraightLeftMove(x, y, phonePad);
            var straightRightMoveResult = StraightRightMove(x, y, phonePad);

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

        private List<Move> DiagLeftUpMove(int x, int y, string[,] phonePad)
        {
            var result = new List<Move>();
            int newY = y - 1;
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
        private List<Move> DiagLeftDownMove(int x, int y, string[,] phonePad)
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
        private List<Move> DiagRightUpMove(int x, int y, string[,] phonePad)
        {
            var result = new List<Move>();
            int newY = y - 1;
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
        private List<Move> DiagRightDownMove(int x, int y, string[,] phonePad)
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
        private List<Move> StraightDownMove(int x, int y, string[,] phonePad)
        {
            var result = new List<Move>();
            int newY = y + 1;
            bool isValid = true;

            if (newY > phonePad.GetLength(0) - 1 || newY < 0)
                isValid = false;

            if (isValid)
                result.Add(new Move() { OldX = x, OldY = y, NewX = x, NewY = newY, Value = phonePad[newY, x] });

            return result;
        }
        private List<Move> StraightUpMove(int x, int y, string[,] phonePad)
        {
            var result = new List<Move>();
            int newY = y - 1;
            bool isValid = true;

            if (newY > phonePad.GetLength(0) - 1 || newY < 0)
                isValid = false;

            if (isValid)
                result.Add(new Move() { OldX = x, OldY = y, NewX = x, NewY = newY, Value = phonePad[newY, x] });

            return result;
        }
        private List<Move> StraightLeftMove(int x, int y, string[,] phonePad)
        {
            var result = new List<Move>();
            int newX = x - 1;
            bool isValid = true;

            if (newX > phonePad.GetLength(1) - 1 || newX < 0)
                isValid = false;

            if (isValid)
                result.Add(new Move() { OldX = x, OldY = y, NewX = newX, NewY = y, Value = phonePad[y, newX] });

            return result;
        }
        private List<Move> StraightRightMove(int x, int y, string[,] phonePad)
        {
            var result = new List<Move>();
            int newX = x + 1;
            bool isValid = true;

            if (newX > phonePad.GetLength(1) - 1 || newX < 0)
                isValid = false;

            if (isValid)
                result.Add(new Move() { OldX = x, OldY = y, NewX = newX, NewY = y, Value = phonePad[y, newX] });

            return result;
        }

    }
}
