namespace GameOfLife.Model
{
    public interface IGameOfLifeRules
    {
        Board ProduceNextGeneration(Board currentGeneration);
    }
}
