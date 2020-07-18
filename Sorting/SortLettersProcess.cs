using System.IO.Compression;
using System.Text;

namespace Sorting
{
    public class SortLettersProcess
    {
        #region METHODS
        
        public string Perform(string text)
        {
            var characterCounter = new CharacterCounter();
            
            characterCounter.Setup();
            if (!string.IsNullOrEmpty(text))
            {
                string textWithOnlyLetters = ExtractLettersFromString(text);
                foreach (var character in textWithOnlyLetters.ToLower())
                    characterCounter.AddCharacter(character);
            }
            return characterCounter.ToString();
        }
        
        #endregion
        
        #region PRIVATE METHODS

        private string ExtractLettersFromString(string text)
        {
            StringBuilder result = new StringBuilder();

            foreach (char character in text)
            {
                if (char.IsLetter(character))
                    result.Append(character);
            }
            return result.ToString();
        }
        
        #endregion
    }
}