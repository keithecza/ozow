using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestUtilities;

namespace GameOfLife.Model.Tests
{
    [TestClass]
    public class BoardTests
    {
        #region INITIALIZE

        [TestInitialize]
        public void Initialize()
        {
            _boardWidth = 12;
            _boardHeight = 13;
            _board = new Board(_boardWidth, _boardHeight);
            _cells = FieldUtilities.GetInternal<bool[,]>(_board, "_cells");
        }

        #endregion

        #region METHODS

        [TestMethod]
        public void Construction()
        {
            Assert.AreEqual(_boardWidth, _board.Width);
            Assert.AreEqual(_boardHeight, _board.Height);
            Assert.AreEqual(_boardHeight, _cells.GetLength(0));
            Assert.AreEqual(_boardWidth, _cells.GetLength(1));

            for (int row = 0; row < _boardHeight; ++row)
                for (int column = 0; column < _boardWidth; ++column)
                    Assert.IsFalse(_cells[row, column]);
        }

        [TestMethod]
        public void IsAlive()
        {
            _cells[8, 3] = true;

            Assert.IsTrue(_board.IsAlive(3, 8));

            _cells[8, 3] = false;

            Assert.IsFalse(_board.IsAlive(3, 8));
        }

        [TestMethod]
        public void SetCellExistence()
        {
            _board.SetCellExistence(6, 7, true);

            Assert.IsTrue(_cells[7, 6]);

            _board.SetCellExistence(6, 7, false);

            Assert.IsFalse(_cells[7, 6]);
        }

        [TestMethod]
        public void LivingNeighboursCount1()
        {
            Assert.AreEqual(0, _board.LivingNeighboursCount(0, 0));

            _board.SetCellExistence(0, 0, true);

            Assert.AreEqual(0, _board.LivingNeighboursCount(0, 0));

            _board.SetCellExistence(1, 0, true);

            Assert.AreEqual(1, _board.LivingNeighboursCount(0, 0));

            _board.SetCellExistence(0, 1, true);

            Assert.AreEqual(2, _board.LivingNeighboursCount(0, 0));

            _board.SetCellExistence(1, 1, true);

            Assert.AreEqual(3, _board.LivingNeighboursCount(0, 0));
        }

        [TestMethod]
        public void LivingNeighboursCount2()
        {
            Assert.AreEqual(0, _board.LivingNeighboursCount(_boardWidth-1, _boardHeight-1));

            _board.SetCellExistence(_boardWidth - 1, _boardHeight - 1, true);

            Assert.AreEqual(0, _board.LivingNeighboursCount(_boardWidth - 1, _boardHeight - 1));

            _board.SetCellExistence(_boardWidth - 2, _boardHeight - 1, true);

            Assert.AreEqual(1, _board.LivingNeighboursCount(_boardWidth - 1, _boardHeight - 1));

            _board.SetCellExistence(_boardWidth - 1, _boardHeight - 2, true);

            Assert.AreEqual(2, _board.LivingNeighboursCount(_boardWidth - 1, _boardHeight - 1));

            _board.SetCellExistence(_boardWidth - 2, _boardHeight - 2, true);

            Assert.AreEqual(3, _board.LivingNeighboursCount(_boardWidth - 1, _boardHeight - 1));
        }

        #endregion

        #region FIELDS

        private int _boardWidth;
        private int _boardHeight;
        private Board _board;
        private bool[,] _cells;

        #endregion
    }
}
