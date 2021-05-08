using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTestWithChess.Models;
using TechTestWithChess.Services;

namespace TechTestWithChess.Tests
{
    [TestClass]
    public class ChessPeiceServiceTests
    {
        [TestMethod]
        public void We_Can_Simulate_Pawn_Chess_Peice_Correctly()
        {
            var sut = new ChessPeiceService();
            var response = sut.SimulateChessPeice(new PawnChessPeice());
            Assert.Equals(response.Count, 0);
        }

        [TestMethod]
        public void We_Can_Simulate_King_Chess_Peice_Correctly()
        {
            var sut = new ChessPeiceService();
            var response = sut.SimulateChessPeice(new PawnChessPeice());
            Assert.Equals(response.Count, 0);
        }

        [TestMethod]
        public void We_Can_Simulate_Bishop_Chess_Peice_Correctly()
        {
            var sut = new ChessPeiceService();
            var response = sut.SimulateChessPeice(new PawnChessPeice());
            Assert.Equals(response.Count, 0);
        }
    }
}
