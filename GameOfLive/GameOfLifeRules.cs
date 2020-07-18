namespace GameOfLife.Model
{
    public class GameOfLifeRules
    {
        public Board ProduceNextGeneration(Board currentGeneration)
        {
            Board newGeneration = new Board(currentGeneration.Width, currentGeneration.Height);

            for (int row = 0; row < currentGeneration.Height; ++row)
            {
                for (int column = 0; column < currentGeneration.Width; ++column)
                {
                    int numberOfLivingNeighbours = currentGeneration.LivingNeighboursCount(column, row);

                    if ((numberOfLivingNeighbours == 2 || numberOfLivingNeighbours == 3) && currentGeneration.IsAlive(column, row))
                        newGeneration.SetCellExistence(column, row, true);
                    if (numberOfLivingNeighbours == 3 && !currentGeneration.IsAlive(column, row))
                        newGeneration.SetCellExistence(column, row, true);
                }
            }

            return newGeneration;
        }
    }
}