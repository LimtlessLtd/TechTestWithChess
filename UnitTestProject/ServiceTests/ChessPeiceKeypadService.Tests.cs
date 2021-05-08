using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTestWithChess.Models;
using TechTestWithChess.Services;

namespace TechTestWithChess.Tests.ServiceTests
{
    [TestClass]
    public class ChessPeiceKeypadServiceTests
    {
        [DataTestMethod]
        [DataRow("fdsfsd", false)]
        [DataRow("1", true)]
        [DataRow("Q", false)]
        [DataRow("6565464", false)]
        public void We_Can_Simulate_Pawn_Chess_Peice_Correctly(string input, bool expectedIsValidResult)
        {
            var sut = new ChessPeiceKeypadService();
            var response = sut.IsValidInput(input);
            Assert.AreEqual(expectedIsValidResult, response.Item1);
        }
    }
}
