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
        public void ShouldBeCompleteIfItDidntFail()
        {
            var cells = new List<Cell>()
            {
                new Cell(new Position(0, 0, 0), true,1),
                new Cell(new Position(1, 0, 1), true,2),
                new Cell(new Position(0, 1, 2), true,3),
                new Cell(new Position(1, 1, 3), true,4),
            };
            var game = new Game(2, 2, cells);

            Assert.AreEqual(Game.GameStatus.Complete, game.GetStatus());
        }
        [TestMethod]
        public void ShouldFailIfVerticalRowMatches()
        {
            var cells = new List<Cell>()
            {
                new Cell(new Position(0, 0, 0), true,1),
                new Cell(new Position(1, 0, 1), true,2),
                new Cell(new Position(0, 1, 2), true,3),
                new Cell(new Position(1, 1, 2), true,3),
            };
            var game = new Game(2, 2, cells);

            Assert.AreEqual(Game.GameStatus.Broken, game.GetStatus());
        }
        [TestMethod]
        public void ShouldFailIfHorizontalRowMatches()
        {
            var cells = new List<Cell>()
            {
                new Cell(new Position(0, 0, 0), true,1),
                new Cell(new Position(1, 0, 1), true,2),
                new Cell(new Position(0, 1, 2), true,1),
                new Cell(new Position(1, 1, 2), true,3),
            };
            var game = new Game(2, 2, cells);

            Assert.AreEqual(Game.GameStatus.Broken, game.GetStatus());
        }
        [TestMethod]
        public void ShouldFailIfGroupMatches()
        {
            var cells = new List<Cell>()
            {
                new Cell(new Position(0, 0, 0), true,1),
                new Cell(new Position(1, 0, 2), true,2),
                new Cell(new Position(0, 1, 2), true,2),
                new Cell(new Position(1, 1, 2), true,1),
            };
            var game = new Game(2, 2, cells);

            Assert.AreEqual(Game.GameStatus.Broken, game.GetStatus());
        }
    }
}
