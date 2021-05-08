using System;
using System.Collections.Generic;
using TechTestWithChess.Models;
using TechTestWithChess.Services.Interfaces;

namespace TechTestWithChess.Services
{
    public class MoveUtilities : IMoveUtilities
    {
        public List<Move> DiagLeftUpMove(int x, int y, string[,] phonePad)
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
        public List<Move> DiagLeftDownMove(int x, int y, string[,] phonePad)
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
        public List<Move> DiagRightUpMove(int x, int y, string[,] phonePad)
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
        public List<Move> DiagRightDownMove(int x, int y, string[,] phonePad)
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
        public List<Move> StraightDownMove(int x, int y, string[,] phonePad)
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
        public List<Move> StraightUpMove(int x, int y, string[,] phonePad)
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
        public List<Move> StraightLeftMove(int x, int y, string[,] phonePad)
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
        public List<Move> StraightRightMove(int x, int y, string[,] phonePad)
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
        //Infinity Move sets
        public List<Move> DiagLeftUpMoveInfinity(int x, int y, string[,] phonePad, List<Move> result, bool isValid = true)
        {
            int newY = y - 1;
            int newX = x - 1;

            if ((newY > phonePad.GetLength(0) - 1 || newY < 0) || (newX > phonePad.GetLength(1) - 1 || newX < 0))
                isValid = false;
            else
            {
                if (isValid)
                    result.AddRange(DiagLeftUpMoveInfinity(newX, newY, phonePad, result, isValid));
            }

            if (isValid)
                result.Add(new Move() { OldX = x, OldY = y, NewX = newX, NewY = newY, Value = phonePad[newY, newX] });

            return result;
        }
        public List<Move> DiagLeftDownMoveInfinity(int x, int y, string[,] phonePad, List<Move> result, bool isValid = true)
        {
            int newY = y + 1;
            int newX = x - 1;

            if ((newY > phonePad.GetLength(0) - 1 || newY < 0) || (newX > phonePad.GetLength(1) - 1 || newX < 0))
                isValid = false;
            else
            {
                if (isValid)
                    result.AddRange(DiagLeftDownMoveInfinity(newX, newY, phonePad, result, isValid));
            }

            if (isValid)
                result.Add(new Move() { OldX = x, OldY = y, NewX = newX, NewY = newY, Value = phonePad[newY, newX] });

            return result;
        }
        public List<Move> DiagRightUpMoveInfinity(int x, int y, string[,] phonePad, List<Move> result, bool isValid = true)
        {
            int newY = y - 1;
            int newX = x + 1;

            if ((newY > phonePad.GetLength(0) - 1 || newY < 0) || (newX > phonePad.GetLength(1) - 1 || newX < 0))
                isValid = false;
            else
            {
                if (isValid)
                    result.AddRange(DiagRightUpMoveInfinity(newX, newY, phonePad, result, isValid));
            }

            if (isValid)
                result.Add(new Move() { OldX = x, OldY = y, NewX = newX, NewY = newY, Value = phonePad[newY, newX] });

            return result;
        }
        public List<Move> DiagRightDownMoveInfinity(int x, int y, string[,] phonePad, List<Move> result, bool isValid = true)
        {
            int newY = y + 1;
            int newX = x + 1;

            if ((newY > phonePad.GetLength(0) - 1 || newY < 0) || (newX > phonePad.GetLength(1) - 1 || newX < 0))
                isValid = false;
            else
            {
                if (isValid)
                    result.AddRange(DiagRightDownMoveInfinity(newX, newY, phonePad, result, isValid));
            }

            if (isValid)
                result.Add(new Move() { OldX = x, OldY = y, NewX = newX, NewY = newY, Value = phonePad[newY, newX] });

            return result;
        }
    }
}
