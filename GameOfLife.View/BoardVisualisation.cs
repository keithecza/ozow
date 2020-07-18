using System;
using System.Collections.Generic;
using System.Resources;
using System.Runtime.ExceptionServices;
using System.Windows;
using System.Windows.Controls;

namespace GameOfLife.View
{
    internal class BoardVisualisation
    {
        public  BoardVisualisation(FrameworkElement canvasContainer, Canvas boardCanvas)
        {
            _canvasContainer = canvasContainer;
            _boardCanvas = boardCanvas;

            _canvasContainer.SizeChanged += OnCanvasContainerSizeChanged;
        }

        private void OnCanvasContainerSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (_boardWidth > 0 && _boardHeight > 0)
            {
                LayoutBoard(_boardWidth, _boardHeight, out double cellSize);
                SetCellBounds(_boardWidth, _boardHeight, cellSize);
            }
        }

        public void SetBoardSize(int width, int height)
        {
            _boardWidth = width;
            _boardHeight = height;

            LayoutBoard(width, height, out double cellSize);
            GenerateCells(width, height);
            SetCellBounds(width, height, cellSize);
        }

        public void Reset()
        {
            for (int row = 0; row < _boardHeight; ++row)
                for (int column = 0; column < _boardWidth; ++column)
                    _cells[row, column].SetExistence(false);
        }

        public List<Tuple<int,int>> GetLiveCells()
        {
            var initialLiveCells = new List<Tuple<int, int>>();

            for (int row = 0; row < _boardHeight; ++row)
                for (int column = 0; column < _boardWidth; ++column)
                {
                    if (_cells[row, column].IsAlive)
                        initialLiveCells.Add(new Tuple<int, int>(column, row));
                }

            return initialLiveCells;
        }

        public void SetCellExistence(int column, int row, bool isAlive)
        {
            _cells[row, column].SetExistence(isAlive);
        }

        private void LayoutBoard(int boardWidth, int boardHeight, out double cellSize)
        {
            double cellHeight = (_canvasContainer.ActualHeight - 2 * BoardMargin) / boardHeight;
            double cellWidth = (_canvasContainer.ActualWidth - 2 * BoardMargin) / boardWidth;

            cellSize = Math.Min(cellHeight, cellWidth);

            _boardCanvas.Width = cellSize * boardWidth;
            _boardCanvas.Height = cellSize * boardHeight;

            double verticalMargin = (_canvasContainer.ActualWidth - _boardCanvas.Width) / 2.0;
            double horizontalMargin = (_canvasContainer.ActualHeight - _boardCanvas.Height) / 2.0;

            _boardCanvas.Margin = new Thickness(verticalMargin, horizontalMargin, verticalMargin, horizontalMargin);
        }

        private void GenerateCells(int boardWidth, int boardHeight)
        {
            _boardCanvas.Children.Clear();
            _cells = new BoardCell[boardHeight, boardWidth];

            for(int row = 0; row < boardHeight; ++row)
                for (int column = 0; column < boardWidth; ++column)
                    _cells[row, column] = new BoardCell(_boardCanvas);
        }

        private void SetCellBounds(int boardWidth, int boardHeight, double cellSize)
        {
            for (int row = 0; row < boardHeight; ++row)
                for (int column = 0; column < boardWidth; ++column)
                    _cells[row, column].SetBounds(new Rect(column * cellSize, row * cellSize, cellSize, cellSize));

        }

        private const double BoardMargin = 8.0;

        private readonly FrameworkElement _canvasContainer;

        private readonly Canvas _boardCanvas;

        private int _boardWidth;

        private int _boardHeight;

        private BoardCell[,] _cells;

    }
}
