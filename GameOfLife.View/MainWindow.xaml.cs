using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        #region CONSTRUCTION

        public MainWindow()
        {
            InitializeComponent();
            _boardVisualisation = new BoardVisualisation(CanvasBorder, Canvas);
            Canvas.Width = Canvas.Height = 0.0;

            Loaded += OnWindowLoaded;
        }

        #endregion

        #region EVENT HANDLERS

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            string[] predefinedBoards = Directory.GetFiles(GetExeFolder(), "*.gol");
            var predefinedBoardsForSelection = new List<string>();

            predefinedBoardsForSelection.Add("");
            predefinedBoardsForSelection.AddRange(predefinedBoards.Select(fullPath => Path.GetFileName(fullPath)).ToList());
            PredefinedBoards.ItemsSource = predefinedBoardsForSelection;
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

        private void OnPredefinedBoardSelected(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var predefinedBoard = PredefinedBoards.SelectedItem.ToString();

            if (!string.IsNullOrEmpty(predefinedBoard))
            {
                string predefinedBoardPath = Path.Combine(GetExeFolder(), predefinedBoard);

                if (File.Exists(predefinedBoardPath))
                {
                    BoardSetup boardSetup = BoardSetup.Load(predefinedBoardPath);

                    Width.Text = boardSetup.Width.ToString();
                    Height.Text = boardSetup.Height.ToString();
                    Generations.Text = boardSetup.NumberOfGenerations.ToString();

                    _boardWidth = boardSetup.Width;
                    _boardHeight = boardSetup.Height;
                    _boardVisualisation.SetBoardSize(_boardWidth, _boardHeight);
                    foreach (Tuple<int, int> liveCell in boardSetup.InitialLiveCells)
                        _boardVisualisation.SetCellExistence(liveCell.Item1, liveCell.Item2, true);
                }
            }
        }

        private void OnStartClicked(object sender, RoutedEventArgs e)
        {
            if (IsBoardSizeValid() && int.TryParse(Generations.Text, out int numberOfGenerations) && numberOfGenerations > 1)
            {
                List<Tuple<int, int>> initialLiveCells = _boardVisualisation.GetLiveCells();
                var gameOfLife = new Model.GameOfLife();

                var boardSetup = new BoardSetup
                {
                    Width = _boardWidth,
                    Height = _boardHeight,
                    NumberOfGenerations = numberOfGenerations,
                    InitialLiveCells = initialLiveCells
                };

                gameOfLife.NextGeneration += OnNextGenerationGenerated;
                Task.Run(() =>
                {
                    gameOfLife.Play(_boardWidth, _boardHeight, numberOfGenerations, new GameOfLifeRules(),  initialLiveCells, 250);
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

        #endregion

        #region PRIVATE METHODS

        private string GetExeFolder()
        {
            return Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
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

        #endregion

        #region FIELDS

        private readonly BoardVisualisation _boardVisualisation;
        private int _boardWidth;
        private int _boardHeight;

        #endregion
    }
}
