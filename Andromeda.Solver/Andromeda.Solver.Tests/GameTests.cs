using System;
using System.Collections.Generic;
using Andromeda.Solver.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Andromeda.Solver.Tests
{
    [TestClass]
    public class GameTests
    {

        [TestMethod]
        public void ShouldBeIncompleteForStartup()
        {
            var game = new Game(2, 2,null);
            Assert.AreEqual(Game.GameStatus.Incomplete,game.GetStatus());
        }
        [TestMethod]
        public void ShouldBeCompleteIfItFailed()
        {
            var cells = new List<Cell>()
            {
                new Cell(new Position(0, 0, 0), true),
                new Cell(new Position(1, 0, 0), true),
                new Cell(new Position(0, 1, 0), true),
                new Cell(new Position(1, 1, 0), true),
            };
            var game = new Game(2, 2, null);

            Assert.AreEqual(Game.GameStatus.Complete, game.GetStatus());
        }
    }
}
