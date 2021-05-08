using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTestWithChess.Models;
using TechTestWithChess.Services;

namespace TechTestWithChess.Tests.ModelTests
{
    [TestClass]
    public class ChessPeiceTests
    {
        public string[,] PhonePad = new string[4, 3]
                                {
                                        {"1","2","3"},
                                        {"4","5","6"},
                                        {"7","8","9"},
                                        {"*","0","#"}
                                };

        [TestMethod]
        public void We_Can_Simulate_Bishop_Chess_Peice_Correctly()
        {
            var startMove = new Move() { NewX = 0, NewY = 0, OldX = 0, OldY = 0, SubsequentMoves = new System.Collections.Generic.List<Move>(), Value = "1" };

            var sut = new BishopChessPeice();
            var result = sut.FindValidMoves(0, 0, PhonePad, 0, startMove);

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("9", result[0].Value);
            Assert.AreEqual(8, result[0].SubsequentMoves.Count);
            Assert.AreEqual("1", result[0].SubsequentMoves[0].Value);
        }

        [TestMethod]
        public void We_Can_Simulate_Pawn_Chess_Peice_Correctly()
        {
            var startMove = new Move() { NewX = 0, NewY = 0, OldX = 0, OldY = 0, SubsequentMoves = new System.Collections.Generic.List<Move>(), Value = "1" };

            var sut = new PawnChessPeice();
            var result = sut.FindValidMoves(0, 0, PhonePad, 0, startMove);

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("4", result[0].Value);
            Assert.AreEqual(2, result[0].SubsequentMoves.Count);
            Assert.AreEqual("7", result[0].SubsequentMoves[0].Value);
        }

        [TestMethod]
        public void We_Can_Simulate_King_Chess_Peice_Correctly()
        {
            var startMove = new Move() { NewX = 0, NewY = 0, OldX = 0, OldY = 0, SubsequentMoves = new System.Collections.Generic.List<Move>(), Value = "1" };

            var sut = new KingChessPeice();
            var result = sut.FindValidMoves(0, 0, PhonePad, 0, startMove);

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("5", result[0].Value);
            Assert.AreEqual(8, result[0].SubsequentMoves.Count);
            Assert.AreEqual("1", result[0].SubsequentMoves[0].Value);
        }
    }
}
