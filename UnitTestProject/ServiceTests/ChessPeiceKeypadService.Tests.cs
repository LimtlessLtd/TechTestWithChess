using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTestWithChess.Models;
using TechTestWithChess.Services;

namespace TechTestWithChess.Tests.ServiceTests
{
    [TestClass]
    public class ChessPieceKeypadServiceTests
    {
        [DataTestMethod]
        [DataRow("fdsfsd", false)]
        [DataRow("1", true)]
        [DataRow("Q", false)]
        [DataRow("6565464", false)]
        public void We_Can_Simulate_Pawn_Chess_Piece_Correctly(string input, bool expectedIsValidResult)
        {
            var sut = new ChessPieceKeypadService();
            var response = sut.IsValidInput(input);
            Assert.AreEqual(expectedIsValidResult, response.Item1);
        }
    }
}
