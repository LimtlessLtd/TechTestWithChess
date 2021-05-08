using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTestWithChess.Models;
using TechTestWithChess.Services;

namespace TechTestWithChess.Tests.ServiceTests
{
    [TestClass]
    public class ChessPeiceServiceTests
    {
        [TestMethod]
        public void We_Can_Simulate_Pawn_Chess_Peice_Correctly()
        {
            var sut = new ChessPeiceService();
            var response = sut.SimulateChessPeice(new PawnChessPeice());
            Assert.AreEqual(0, response.Count);
        }

        [TestMethod]
        public void We_Can_Simulate_King_Chess_Peice_Correctly()
        {
            var sut = new ChessPeiceService();
            var response = sut.SimulateChessPeice(new KingChessPeice());
            Assert.AreEqual(124908, response.Count);
        }

        [TestMethod]
        public void We_Can_Simulate_Bishop_Chess_Peice_Correctly()
        {
            var sut = new ChessPeiceService();
            var response = sut.SimulateChessPeice(new BishopChessPeice());
            Assert.AreEqual(2341, response.Count);
        }

        [DataTestMethod]
        [DataRow("1234567", 1, 2, 3, 4, 5, 6, 7)]
        [DataRow("6666666", 6, 6, 6, 6, 6, 6, 6)]
        [DataRow("5434567", 5, 4, 3, 4, 5, 6, 7)]
        public void We_Can_Get_Information(string fullNo, int oneth, int twoth, int threeth, int fourth, int fifth, int sixth, int seventh)
        {
            var sut = new ChessPeiceService();
            var test = SetupTestSpiderWeb(oneth, twoth, threeth, fourth, fifth, sixth, seventh);

            var response = sut.RecursionForGettingPhoneNumber(test, new System.Collections.Generic.List<string>());
            Assert.AreEqual(fullNo, response.FindAll(x => x.Length >= 7)[0]);
        }

        private System.Collections.Generic.List<Move> SetupTestSpiderWeb(int oneth, int twoth, int threeth, int fourth, int fifth, int sixth, int seventh)
        {
           return new System.Collections.Generic.List<Move>() {
                new Move()
                {
                    Value = oneth.ToString(),
                    SubsequentMoves = new System.Collections.Generic.List<Move>(){
                        new Move()
                        {
                            Value = twoth.ToString(),
                            SubsequentMoves = new System.Collections.Generic.List<Move>(){
                                new Move()
                                {
                                    Value = threeth.ToString(),
                                    SubsequentMoves = new System.Collections.Generic.List<Move>()
                                    {
                                        new Move()
                                        {
                                            Value = fourth.ToString(),
                                            SubsequentMoves = new System.Collections.Generic.List<Move>()
                                            {
                                                new Move()
                                                {
                                                    Value = fifth.ToString(),
                                                    SubsequentMoves = new System.Collections.Generic.List<Move>()
                                                    {
                                                        new Move()
                                                        {
                                                            Value = sixth.ToString(),
                                                            SubsequentMoves = new System.Collections.Generic.List<Move>()
                                                            {
                                                                new Move()
                                                                {
                                                                    Value = seventh.ToString(),
                                                                    SubsequentMoves = new System.Collections.Generic.List<Move>()
                                                                    {

                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
