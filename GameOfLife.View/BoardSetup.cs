using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace GameOfLife.View
{
    internal class BoardSetup
    {
        #region PROPERTIES

        public int Width { get; set; }

        public int Height { get; set; }

        public int NumberOfGenerations { get; set; }

        public List<Tuple<int,int>> InitialLiveCells { get; set; }

        #endregion

        #region METHODS

        public void Save(string filePath)
        {
            string json = JsonConvert.SerializeObject(this);

            File.WriteAllText(filePath, json);
        }

        public static BoardSetup Load(string filePath)
        {
            string json = File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<BoardSetup>(json);
        }

        #endregion
    }
}
