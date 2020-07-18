using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using GameOfLife.Model;

namespace GameOfLife.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _boardVisualisation = new BoardVisualisation(CanvasBorder, Canvas);
            Canvas.Width = Canvas.Height = 0.0;
        }

        private void OnWidthLostFocus(object sender, RoutedEventArgs e)
        {
            SetBoardSize();
        }

        private void OnHeightLostFocus(object sender, RoutedEventArgs e)
        {
            SetBoardSize();
        }

        private void OnResetBoardClicked(object sender, RoutedEventArgs e)
        {
            _boardVisualisation.Reset();
        }

        private void OnStartClicked(object sender, RoutedEventArgs e)
        {
            if (IsBoardSizeValid() && int.TryParse(Generations.Text, out int numberOfGenerations) && numberOfGenerations > 1)
            {
                List<Tuple<int, int>> initialLiveCells = _boardVisualisation.GetLiveCells();
                var gameOfLife = new Model.GameOfLife();

                gameOfLife.NextGeneration += OnNextGenerationGenerated;
                Task.Run(() =>
                {
                    gameOfLife.Play(_boardWidth, _boardHeight, numberOfGenerations, initialLiveCells);
                });
            }
        }

        private void OnNextGenerationGenerated(object sender, NextGenerationEventArgs args)
        {
            Dispatcher.Invoke(() =>
            {
                for (int row = 0; row < _boardHeight; ++row)
                    for (int column = 0; column < _boardWidth; ++column)
                        _boardVisualisation.SetCellExistence(column, row, args.Board.IsAlive(column, row));
            });
        }

        private void SetBoardSize()
        {
            if (int.TryParse(Width.Text, out _boardWidth) && int.TryParse(Height.Text, out _boardHeight) && IsBoardSizeValid())
                _boardVisualisation.SetBoardSize(_boardWidth, _boardHeight);
        }

        private bool IsBoardSizeValid()
        {
            return _boardWidth > 1 && _boardHeight > 1;
        }

        private BoardVisualisation _boardVisualisation;

        private int _boardWidth;

        private int _boardHeight;
    }
}
