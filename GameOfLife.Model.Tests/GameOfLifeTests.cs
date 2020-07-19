using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.Model.Tests
{
    [TestClass]
    public class GameOfLifeTests
    {
        #region TESTS
        
        [TestMethod]
        [Description("Initial living cell column < 0")]
        [ExpectedException(typeof(Exception), "Cannot bring the cell (-1, 0) into existence as it not present on the board. -1 should be greater that 0 and less than 3")]
        public void Play1()
        {
            var gameOfLife = new GameOfLife();
            
            gameOfLife.Play(3, 3, 1, new MockRules(), new Tuple<int, int>[] {new Tuple<int, int>(-1,0)}, 0);
        }
        
        [TestMethod]
        [Description("Initial living cell column >= width")]
        [ExpectedException(typeof(Exception), "Cannot bring the cell (3, 0) into existence as it not present on the board. -1 should be greater that 0 and less than 3")]
        public void Play2()
        {
            var gameOfLife = new GameOfLife();
            
            gameOfLife.Play(3, 3, 1, new MockRules(), new Tuple<int, int>[] {new Tuple<int, int>(3,0)}, 0);
        }
        
        [TestMethod]
        [Description("Initial living cell row < 0")]
        [ExpectedException(typeof(Exception), "Cannot bring the cell (0, -1) into existence as it not present on the board. -1 should be greater that 0 and less than 3")]
        public void Play3()
        {
            var gameOfLife = new GameOfLife();
            
            gameOfLife.Play(3, 3, 1, new MockRules(), new Tuple<int, int>[] {new Tuple<int, int>(0,-1)}, 0);
        }
        
        [TestMethod]
        [Description("Initial living cell row >= height")]
        [ExpectedException(typeof(Exception), "Cannot bring the cell (0,3) into existence as it not present on the board. 3 should be greater that 0 and less than 3")]
        public void Play4()
        {
            var gameOfLife = new GameOfLife();
            
            gameOfLife.Play(3, 3, 1, new MockRules(), new Tuple<int, int>[] {new Tuple<int, int>(0,3)}, 0);
        }
        
        [TestMethod]
        [Description("Test the actual generating of new generations")]
        public void Play5()
        {
            var gameOfLife = new GameOfLife();
            var generatedBoards = new List<Board>();
            var mockRules = new MockRules();

            gameOfLife.NextGeneration += (sender, args) =>
            {
                generatedBoards.Add(args.Board);
            };
            
            gameOfLife.Play(2, 2, 2, mockRules, 
                new Tuple<int, int>[] {
                    new Tuple<int, int>(0,0),
                    new Tuple<int, int>(1,1)}, 0);
            
            Assert.AreEqual(3, generatedBoards.Count);
            Assert.AreEqual(2, mockRules.NumberOfGenerations);
            
            Assert.IsTrue(generatedBoards[0].IsAlive(0, 0));
            Assert.IsFalse(generatedBoards[0].IsAlive(1, 0));
            Assert.IsFalse(generatedBoards[0].IsAlive(0, 1));
            Assert.IsTrue(generatedBoards[0].IsAlive(1, 1));

            Assert.IsTrue(generatedBoards[1].IsAlive(0, 0));
            Assert.IsTrue(generatedBoards[1].IsAlive(1, 0));
            Assert.IsTrue(generatedBoards[1].IsAlive(0, 1));
            Assert.IsTrue(generatedBoards[1].IsAlive(1, 1));

            Assert.IsFalse(generatedBoards[2].IsAlive(0, 0));
            Assert.IsFalse(generatedBoards[2].IsAlive(1, 0));
            Assert.IsFalse(generatedBoards[2].IsAlive(0, 1));
            Assert.IsFalse(generatedBoards[2].IsAlive(1, 1));
        }
        
        #endregion
    }
}