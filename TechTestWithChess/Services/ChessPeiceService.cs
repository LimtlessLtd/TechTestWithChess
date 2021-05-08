using System;
using System.Collections.Generic;
using System.Linq;
using TechTestWithChess.Model.Interfaces;
using TechTestWithChess.Models;
using TechTestWithChess.Services.Interfaces;

namespace TechTestWithChess.Services
{
    public class ChessPeiceService : IChessPeiceService
    {
        public List<string> SimulateChessPeice(IChessPeice chessPeice)
        {
            var result = new List<string>();

            string[,] phonePad = new string[4,3] 
                                    {
                                        {"1","2","3"},
                                        {"4","5","6"},
                                        {"7","8","9"},
                                        {"*","0","#"}
                                    };

            var MoveSet = new List<Move>();

            for (int y = 0; y < phonePad.GetLength(0); y++)
            {
                for (int x = 0; x < phonePad.GetLength(1); x++)
                {
                    var parent = new Move()
                                {
                                    OldX = x,
                                    OldY = y,
                                    NewX = x,
                                    NewY = y,
                                    SubsequentMoves = new List<Move>(),
                                    Value = phonePad[y, x]
                                };

                    parent.SubsequentMoves.AddRange(chessPeice.FindValidMoves(x, y, phonePad, 0, parent));

                    MoveSet.Add(parent);
                }
            }

            result.AddRange(GetValidResultsFromMoveSet(MoveSet));

            result = result.FindAll(x => x.Length >= 7 && 
                                !x.StartsWith("0") && 
                                !x.StartsWith("1") && 
                                !x.Contains("*") && 
                                !x.Contains("#")
                            ).Distinct().ToList();

            return result;
        }

        private List<string> GetValidResultsFromMoveSet(List<Move> moveSet, int childrenCount = 0)
        {
            var listResult = new List<string>();
            var first = new List<string>();

            foreach (var move in moveSet)
            {
                first.Add(move.Value);
                listResult.AddRange(RecursionForGettingPhoneNumber(move.SubsequentMoves, first));
            }

            return listResult;
        }
        public List<string> RecursionForGettingPhoneNumber(List<Move> moveset, List<string> currentstrings)
        {
            foreach (var item in moveset)
            {
                if (currentstrings.Count > 0)
                    currentstrings.Add(currentstrings[currentstrings.Count - 1] + item.Value);
                else
                    currentstrings.Add(item.Value);

                RecursionForGettingPhoneNumber(item.SubsequentMoves, currentstrings);
                if (currentstrings.Count > 0)
                    currentstrings.Add(currentstrings[currentstrings.Count - 1].Remove(currentstrings[currentstrings.Count - 1].Length - 1));
            }
            return currentstrings;
        }
    }
}
