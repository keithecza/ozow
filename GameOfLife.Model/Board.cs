using System.Diagnostics;

namespace GameOfLife.Model
{
    public class Board
    {
        #region PROPERTIES

        public int Width { get; }
        
        public int Height { get; }

        #endregion

        #region CONSTRUCTION

        public Board(int width, int height)
        {
            Debug.Assert(width > 0);
            Debug.Assert(height > 0);
            
            Width = width;
            Height = height;
            _cells = new bool[height, width];
        }

        #endregion

        #region METHODS

        public bool IsAlive(int x, int y)
        {
            Debug.Assert(x >= 0);
            Debug.Assert(x < Width);
            Debug.Assert(y >= 0);
            Debug.Assert(y < Height);

            return _cells[y, x];
        }

        public void SetCellExistence(int x, int y, bool alive)
        {
            Debug.Assert(x >= 0);
            Debug.Assert(x < Width);
            Debug.Assert(y >= 0);
            Debug.Assert(y < Height);
            
            _cells[y, x] = alive;
        }
        
        public int LivingNeighboursCount(int x, int y)
        {
            Debug.Assert(x >= 0);
            Debug.Assert(x < Width);
            Debug.Assert(y >= 0);
            Debug.Assert(y < Height);
            
            int neighbourCount = 0;
            
            for(int row = y-1; row <= y+1; ++row)
            {
                for(int column = x - 1; column <= x + 1; ++column)
                {
                    bool mustSkipCell = row < 0 || row >= Height || column < 0 || column >= Width || (row == y && column == x);

                    if (mustSkipCell)
                        continue;
                    neighbourCount += (_cells[row, column]) ? 1 : 0;
                }
            }

            return neighbourCount;
        }

        #endregion

        #region FIELDS

        private readonly bool[,] _cells;

        #endregion
    }
}