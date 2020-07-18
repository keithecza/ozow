using System;
using System.Collections.Generic;
using System.Threading;

namespace GameOfLife.Model
{
    public class GameOfLife
    {
        public event NextGenerationEventHandler NextGeneration;
        
        public void Play(int boardWidth, int boardHeight, int numberOfGenerations, IEnumerable<Tuple<int, int>> initialLivingCells)
        {
            Board board = new Board(boardWidth, boardHeight);

            foreach (var currentLivingCell in initialLivingCells)
            {
                if (currentLivingCell.Item1 < 0 || currentLivingCell.Item1 > boardWidth)
                    throw new Exception($"Cannot bring the cell ({currentLivingCell.Item1}, {currentLivingCell.Item2}) into existence as it not present on the board." + 
                        $"{currentLivingCell.Item1} should be greater that 0 and less than {boardWidth}");
                if (currentLivingCell.Item2 < 0 || currentLivingCell.Item2 > boardHeight)
                    throw new Exception($"Cannot bring the cell ({currentLivingCell.Item1}, {currentLivingCell.Item2}) into existence as it not present on the board." + 
                        $"{currentLivingCell.Item2} should be greater that 0 and less than {boardHeight}");
                
                board.SetCellExistence(currentLivingCell.Item1, currentLivingCell.Item2, true);
            }
            
            GameOfLifeRules rules = new GameOfLifeRules();
            
            for (int generationCount = 1; generationCount <= numberOfGenerations; ++generationCount)
            {
                board = rules.ProduceNextGeneration(board);
                NextGeneration?.Invoke(this, new NextGenerationEventArgs(board));
                Thread.Sleep(333);
            }
        }
    }
}