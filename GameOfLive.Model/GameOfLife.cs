using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace GameOfLife.Model
{
    public class GameOfLife
    {
        #region EVENTS

        public event NextGenerationEventHandler NextGeneration;

        #endregion

        #region METHODS

        public void Play(int boardWidth, int boardHeight, int numberOfGenerations, IGameOfLifeRules rules, IEnumerable<Tuple<int, int>> initialLivingCells, int delayInMS)
        {
            Debug.Assert(boardWidth > 1);
            Debug.Assert(boardHeight > 1);
            Debug.Assert(numberOfGenerations > 0);
            Debug.Assert(rules != null);

            Board board = new Board(boardWidth, boardHeight);

            foreach (var currentLivingCell in initialLivingCells)
            {
                if (currentLivingCell.Item1 < 0 || currentLivingCell.Item1 >= boardWidth)
                    throw new Exception($"Cannot bring the cell ({currentLivingCell.Item1}, {currentLivingCell.Item2}) into existence as it not present on the board." + 
                        $"{currentLivingCell.Item1} should be greater that 0 and less than {boardWidth}");
                if (currentLivingCell.Item2 < 0 || currentLivingCell.Item2 >= boardHeight)
                    throw new Exception($"Cannot bring the cell ({currentLivingCell.Item1}, {currentLivingCell.Item2}) into existence as it not present on the board." + 
                        $"{currentLivingCell.Item2} should be greater that 0 and less than {boardHeight}");
                
                board.SetCellExistence(currentLivingCell.Item1, currentLivingCell.Item2, true);
            }

            NextGeneration?.Invoke(this, new NextGenerationEventArgs(board));
            for (int generationCount = 1; generationCount <= numberOfGenerations; ++generationCount)
            {
                board = rules.ProduceNextGeneration(board);
                NextGeneration?.Invoke(this, new NextGenerationEventArgs(board));
                
                if (delayInMS > 0)
                    Thread.Sleep(delayInMS);
            }
        }

        #endregion
    }
}