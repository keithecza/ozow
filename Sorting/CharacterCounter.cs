using System;
using System.Text;
using System.Diagnostics;

namespace Sorting
{
    public class CharacterCounter
    {
        #region CONSTRUCTION
        
        public CharacterCounter()
        {
            _characterCounts = new int[NumberOfCharactersInLatinAlphabet];
            _characters = new char[NumberOfCharactersInLatinAlphabet];   
        }
        
        public void Setup()
        {
            for (var index = 0; index < NumberOfCharactersInLatinAlphabet; ++index)
                _characters[index] = (char) ('a' + index);
        }
        
        #endregion
        
        #region METHODS
        
        public void AddCharacter(char character)
        {
            Debug.Assert(Char.IsLower(character), "character must be lower case");
            Debug.Assert(_characterCounts.Length > 0, "CharacterCounter.Setup must be called before calling AddCharacter");
            
            _characterCounts[character - 'a'] += 1;
        }

        public override string ToString()
        {
            Debug.Assert(_characterCounts.Length > 0, "CharacterCounter.Setup must be called before calling ToString");
            
            StringBuilder stringValue = new StringBuilder();

            for (int index = 0; index < NumberOfCharactersInLatinAlphabet; ++index)
            {
                if (_characterCounts[index] > 0)
                    stringValue.Append(_characters[index], _characterCounts[index]);
            }
            return stringValue.ToString();
        }
        
        #endregion
        
        #region FIELDS

        private const int NumberOfCharactersInLatinAlphabet = 26;
        
        private readonly char[] _characters;
        private readonly int[] _characterCounts;
        
        #endregion
    }
}