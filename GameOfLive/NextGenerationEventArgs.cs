using System;

namespace GameOfLife.Model
{
    public delegate void NextGenerationEventHandler(object sender, NextGenerationEventArgs args);
    
    public class NextGenerationEventArgs : EventArgs
    {
        #region PROPERTIES
        
        public Board Board { get; }
        
        #endregion
        
        #region CONSTRUCTION

        public NextGenerationEventArgs(Board board)
        {
            Board = board;
        }
        
        #endregion
    }
}