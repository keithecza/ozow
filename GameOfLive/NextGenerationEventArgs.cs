using System;

namespace GameOfLive
{
    public delegate void NextGenerationEventHandler(object sender, NextGenerationEventArgs args);
    
    public class NextGenerationEventArgs : EventArgs
    {
        public Board Board { get; }

        public NextGenerationEventArgs(Board board)
        {
            Board = board;
        }
    }
}