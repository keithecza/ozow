using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.Model.Tests
{
    [TestClass]
    public class GameOfLifeRulesTests
    {
        #region TEST

        /// <summary>
        /// The following board tests all rules
        /// Before:
        /// 
        /// +---+---+---+---+
        /// | X |   | X |   |
        /// +---+---+---+---+
        /// | X | X | X | X |
        /// +---+---+---+---+
        /// | X | X | X |   |
        /// +---+---+---+---+
        /// |   |   |   |   |
        /// +---+---+---+---+
        /// 
        /// After:
        /// 
        /// +---+---+---+---+
        /// | X |   | X | X |
        /// +---+---+---+---+
        /// |   |   |   | X |
        /// +---+---+---+---+
        /// | X |   |   | X |
        /// +---+---+---+---+
        /// |   | X |   |   |
        /// +---+---+---+---+
        ///  Verified at https://bitstorm.org/gameoflife/
        /// </summary>
        [TestMethod]
        public void ProduceNextGeneration1()
        {
            var board = new Board(4, 4);
            var gameOfLifeRule = new GameOfLifeRules();

            board.SetCellExistence(0, 0, true);
            board.SetCellExistence(2, 0, true);
            board.SetCellExistence(0, 1, true);
            board.SetCellExistence(1, 1, true);
            board.SetCellExistence(2, 1, true);
            board.SetCellExistence(3, 1, true);
            board.SetCellExistence(0, 2, true);
            board.SetCellExistence(1, 2, true);
            board.SetCellExistence(2, 2, true);

            Board nextGeneration = gameOfLifeRule.ProduceNextGeneration(board);

            Assert.IsTrue(nextGeneration.IsAlive(0, 0));
            Assert.IsFalse(nextGeneration.IsAlive(1, 0));
            Assert.IsTrue(nextGeneration.IsAlive(2, 0));
            Assert.IsTrue(nextGeneration.IsAlive(3, 0));

            Assert.IsFalse(nextGeneration.IsAlive(0, 1));
            Assert.IsFalse(nextGeneration.IsAlive(1, 1));
            Assert.IsFalse(nextGeneration.IsAlive(2, 1));
            Assert.IsTrue(nextGeneration.IsAlive(3, 1));

            Assert.IsTrue(nextGeneration.IsAlive(0, 2));
            Assert.IsFalse(nextGeneration.IsAlive(1, 2));
            Assert.IsFalse(nextGeneration.IsAlive(2, 2));
            Assert.IsTrue(nextGeneration.IsAlive(3, 2));

            Assert.IsFalse(nextGeneration.IsAlive(0, 3));
            Assert.IsTrue(nextGeneration.IsAlive(1, 3));
            Assert.IsFalse(nextGeneration.IsAlive(2, 3));
            Assert.IsFalse(nextGeneration.IsAlive(3, 3));
        }

        /// <summary>
        /// The Blinker
        /// Before:
        /// 
        /// +---+---+---+
        /// |   | X |   |
        /// +---+---+---+
        /// |   | X |   |
        /// +---+---+---+
        /// |   | X |   |
        /// +---+---+---+
        /// 
        /// After:
        /// 
        /// +---+---+---+
        /// |   |   |   |
        /// +---+---+---+
        /// | X | X | X |
        /// +---+---+---+
        /// |   |   |   |
        /// +---+---+---+
        /// 
        /// And the repeat
        /// </summary>
        [TestMethod]
        public void ProduceNextGeneration2()
        {
            var board = new Board(3, 3);
            var gameOfLifeRule = new GameOfLifeRules();

            board.SetCellExistence(1, 0, true);
            board.SetCellExistence(1, 1, true);
            board.SetCellExistence(1, 2, true);

            Board nextGeneration = gameOfLifeRule.ProduceNextGeneration(board);

            Assert.IsFalse(nextGeneration.IsAlive(0, 0));
            Assert.IsFalse(nextGeneration.IsAlive(1, 0));
            Assert.IsFalse(nextGeneration.IsAlive(2, 0));

            Assert.IsTrue(nextGeneration.IsAlive(0, 1));
            Assert.IsTrue(nextGeneration.IsAlive(1, 1));
            Assert.IsTrue(nextGeneration.IsAlive(2, 1));

            Assert.IsFalse(nextGeneration.IsAlive(0, 2));
            Assert.IsFalse(nextGeneration.IsAlive(1, 2));
            Assert.IsFalse(nextGeneration.IsAlive(2, 2));

            nextGeneration = gameOfLifeRule.ProduceNextGeneration(nextGeneration);

            Assert.IsFalse(nextGeneration.IsAlive(0, 0));
            Assert.IsTrue(nextGeneration.IsAlive(1, 0));
            Assert.IsFalse(nextGeneration.IsAlive(2, 0));

            Assert.IsFalse(nextGeneration.IsAlive(0, 1));
            Assert.IsTrue(nextGeneration.IsAlive(1, 1));
            Assert.IsFalse(nextGeneration.IsAlive(2, 1));

            Assert.IsFalse(nextGeneration.IsAlive(0, 2));
            Assert.IsTrue(nextGeneration.IsAlive(1, 2));
            Assert.IsFalse(nextGeneration.IsAlive(2, 2));
        }
        
        #endregion
    }
}
