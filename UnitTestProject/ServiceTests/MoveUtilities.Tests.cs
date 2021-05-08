using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTestWithChess.Models;
using TechTestWithChess.Services;

namespace TechTestWithChess.Tests.ServiceTests
{
    [TestClass]
    public class MoveUtilitiesTests
    {
        public string[,] PhonePad = new string[4, 3]
                                {
                                        {"1","2","3"},
                                        {"4","5","6"},
                                        {"7","8","9"},
                                        {"*","0","#"}
                                };

        [TestMethod]
        public void We_Can_Simulate_Straight_Down_Move_Correctly()
        {
            var sut = new MoveUtilities();
            var response = sut.StraightDownMove(0, 0, PhonePad);
            Assert.AreEqual(1, response.Count);
            Assert.AreEqual(1, response[0].NewY);
            Assert.AreEqual(0, response[0].NewX);
        }

        [TestMethod]
        public void We_Can_Simulate_Straight_Up_Move_Correctly()
        {
            var sut = new MoveUtilities();
            var response = sut.StraightUpMove(1, 1, PhonePad);
            Assert.AreEqual(1, response.Count);
            Assert.AreEqual(0, response[0].NewY);
            Assert.AreEqual(1, response[0].NewX);
        }

        [TestMethod]
        public void We_Can_Simulate_Straight_Left_Move_Correctly()
        {
            var sut = new MoveUtilities();
            var response = sut.StraightLeftMove(1, 1, PhonePad);
            Assert.AreEqual(1, response.Count);
            Assert.AreEqual(1, response[0].NewY);
            Assert.AreEqual(0, response[0].NewX);
        }

        [TestMethod]
        public void We_Can_Simulate_Straight_Right_Move_Correctly()
        {
            var sut = new MoveUtilities();
            var response = sut.StraightLeftMove(1, 1, PhonePad);
            Assert.AreEqual(1, response.Count);
            Assert.AreEqual(1, response[0].NewY);
            Assert.AreEqual(0, response[0].NewX);
        }

        [TestMethod]
        public void We_Can_Simulate_DiagLeftDownMove_Correctly()
        {
            var sut = new MoveUtilities();
            var response = sut.DiagLeftDownMove(1, 1, PhonePad);
            Assert.AreEqual(1, response.Count);
            Assert.AreEqual(2, response[0].NewY);
            Assert.AreEqual(0, response[0].NewX);
        }

        [TestMethod]
        public void We_Can_Simulate_DiagLeftUpMove_Correctly()
        {
            var sut = new MoveUtilities();
            var response = sut.DiagLeftUpMove(1, 1, PhonePad);
            Assert.AreEqual(1, response.Count);
            Assert.AreEqual(0, response[0].NewY);
            Assert.AreEqual(0, response[0].NewX);
        }

        [TestMethod]
        public void We_Can_Simulate_DiagRightDownMove_Correctly()
        {
            var sut = new MoveUtilities();
            var response = sut.DiagRightDownMove(1, 1, PhonePad);
            Assert.AreEqual(1, response.Count);
            Assert.AreEqual(2, response[0].NewY);
            Assert.AreEqual(2, response[0].NewX);
        }

        [TestMethod]
        public void We_Can_Simulate_DiagRightUpMove_Correctly()
        {
            var sut = new MoveUtilities();
            var response = sut.DiagRightUpMove(1, 1, PhonePad);
            Assert.AreEqual(1, response.Count);
            Assert.AreEqual(0, response[0].NewY);
            Assert.AreEqual(2, response[0].NewX);
        }

        [TestMethod]
        public void We_Can_Simulate_DiagLeftDownMoveInfinity_Correctly()
        {
            var sut = new MoveUtilities();
            var response = sut.DiagLeftDownMoveInfinity(2, 0, PhonePad, new System.Collections.Generic.List<Move>());
            Assert.AreEqual(3, response.Count);
            Assert.AreEqual(2, response[0].NewY);
            Assert.AreEqual(0, response[0].NewX);
        }

        [TestMethod]
        public void We_Can_Simulate_DiagLeftUpMoveInfinity_Correctly()
        {
            var sut = new MoveUtilities();
            var response = sut.DiagLeftUpMoveInfinity(2, 3, PhonePad, new System.Collections.Generic.List<Move>());
            Assert.AreEqual(3, response.Count);
            Assert.AreEqual(1, response[0].NewY);
            Assert.AreEqual(0, response[0].NewX);
        }

        [TestMethod]
        public void We_Can_Simulate_DiagRightDownMoveInfinity_Correctly()
        {
            var sut = new MoveUtilities();
            var response = sut.DiagRightDownMoveInfinity(0, 0, PhonePad, new System.Collections.Generic.List<Move>());
            Assert.AreEqual(3, response.Count);
            Assert.AreEqual(2, response[0].NewY);
            Assert.AreEqual(2, response[0].NewX);
        }

        [TestMethod]
        public void We_Can_Simulate_DiagRightUpMoveInfinity_Correctly()
        {
            var sut = new MoveUtilities();
            var response = sut.DiagRightUpMoveInfinity(0, 3, PhonePad, new System.Collections.Generic.List<Move>());
            Assert.AreEqual(3, response.Count);
            Assert.AreEqual(1, response[0].NewY);
            Assert.AreEqual(2, response[0].NewX);
        }
    }
}
