using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GameOfLife.View
{
    internal class BoardCell
    {
        public bool IsAlive { get; private set; }

        public BoardCell(Canvas boardCanvas)
        {
            _boardCanvas = boardCanvas;
        }

        public void SetBounds(Rect bounds)
        {
            if (_rectangle == null)
            {
                _rectangle = new Rectangle
                {
                    StrokeThickness = 4.0
                };

                _rectangle.MouseEnter += OnMouseEnter;
                _rectangle.MouseLeave += OnMouseLeave;
                _rectangle.MouseLeftButtonUp += OnMouseUp;

                _boardCanvas.Children.Add(_rectangle);
            }

            Canvas.SetLeft(_rectangle, bounds.Left);
            Canvas.SetTop(_rectangle, bounds.Top);
            _rectangle.Width = bounds.Width;
            _rectangle.Height = bounds.Height;

            ShowCell(IsAlive, false);
        }

        public void SetExistence(bool isAlive)
        {
            IsAlive = isAlive;
            ShowCell(IsAlive, false);
        }

        private void OnMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            IsAlive = !IsAlive;
            ShowCell(IsAlive, true);
        }

        private void OnMouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ShowCell(IsAlive, false);
        }

        private void OnMouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ShowCell(IsAlive, true);
        }

        private void ShowCell(bool isAlive, bool isUnderCursor)
        {
            if (isUnderCursor)
                _rectangle.Stroke = Brushes.Blue;
            else if (isAlive)
                _rectangle.Stroke = Brushes.White;
            else
                _rectangle.Stroke = Brushes.Transparent;

            if (isAlive)
                _rectangle.Fill = Brushes.White;
            else
                _rectangle.Fill = Brushes.Transparent;
        }

        private Canvas _boardCanvas;

        private Rectangle _rectangle;
    }
}
