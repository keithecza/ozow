namespace GameOfLife.Model.Tests
{
    public class MockRules : IGameOfLifeRules
    {
        #region PROPERTIES

        public int NumberOfGenerations { get; private set; }

        #endregion

        #region METHODS

        public Board ProduceNextGeneration(Board board)
        {
            var nextGeneration = new Board(board.Width, board.Height);
            NumberOfGenerations += 1;

            SetForAllCells(nextGeneration, NumberOfGenerations % 2 == 1);

            return nextGeneration;
        }

        #endregion

        #region PRIVATE METHODS

        private void SetForAllCells(Board board, bool isALive)
        {
            for (int row = 0; row < board.Height; ++row)
                for (int column = 0; column < board.Width; ++column)
                    board.SetCellExistence(column, row, isALive);
        }

        #endregion
    }
}
