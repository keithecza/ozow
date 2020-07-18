using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestUtilities;

namespace Sorting.Tests
{
    [TestClass]
    public class CharacterCounterTests
    {
        #region INITIALIZATION
        
        [TestInitialize]
        public void Initialize()
        {
            _characterCounter = new CharacterCounter();
        }

        #endregion
        
        #region TESTS

        [TestMethod]
        public void Constructor()
        {
            var characters = FieldUtilities.GetInternal<char[]>(_characterCounter, "_characters");
            var characterCounts = FieldUtilities.GetInternal<int[]>(_characterCounter, "_characterCounts");
            
            Assert.AreEqual(26, characters.Length);
            Assert.AreEqual(26, characterCounts.Length);
        }
        
        [TestMethod]
        public void Setup()
        {
            _characterCounter.Setup();
            
            var characters = FieldUtilities.GetInternal<char[]>(_characterCounter, "_characters");
            
            Assert.AreEqual('a', characters[0]);
            Assert.AreEqual('b', characters[1]);
            Assert.AreEqual('c', characters[2]);
            Assert.AreEqual('d', characters[3]);
            Assert.AreEqual('e', characters[4]);
            Assert.AreEqual('f', characters[5]);
            Assert.AreEqual('g', characters[6]);
            Assert.AreEqual('h', characters[7]);
            Assert.AreEqual('i', characters[8]);
            Assert.AreEqual('j', characters[9]);
            Assert.AreEqual('k', characters[10]);
            Assert.AreEqual('l', characters[11]);
            Assert.AreEqual('m', characters[12]);
            Assert.AreEqual('n', characters[13]);
            Assert.AreEqual('o', characters[14]);
            Assert.AreEqual('p', characters[15]);
            Assert.AreEqual('q', characters[16]);
            Assert.AreEqual('r', characters[17]);
            Assert.AreEqual('s', characters[18]);
            Assert.AreEqual('t', characters[19]);
            Assert.AreEqual('u', characters[20]);
            Assert.AreEqual('v', characters[21]);
            Assert.AreEqual('w', characters[22]);
            Assert.AreEqual('x', characters[23]);
            Assert.AreEqual('y', characters[24]);
            Assert.AreEqual('z', characters[25]);
        }

        [TestMethod]
        public void AddCharacter()
        {
            _characterCounter.Setup();
            
            var characterCounts = FieldUtilities.GetInternal<int[]>(_characterCounter, "_characterCounts");
            
            Assert.AreEqual(0, characterCounts['a'- 'a']);
            Assert.AreEqual(0, characterCounts['z' - 'a']);
            
            _characterCounter.AddCharacter('a');
            _characterCounter.AddCharacter('z');
            
            Assert.AreEqual(1, characterCounts['a' - 'a']);
            Assert.AreEqual(1, characterCounts['z' - 'a']);
            
            _characterCounter.AddCharacter('z');
            
            Assert.AreEqual(1, characterCounts['a' - 'a']);
            Assert.AreEqual(2, characterCounts['z' - 'a']);
        }

        [TestMethod]
        public void ToStringTest()
        {
            _characterCounter.Setup();

            Assert.AreEqual("", _characterCounter.ToString());
            
            _characterCounter.AddCharacter('a');
            
            Assert.AreEqual("a", _characterCounter.ToString());
            
            _characterCounter.AddCharacter('a');
            _characterCounter.AddCharacter('b');
            _characterCounter.AddCharacter('z');
            
            Assert.AreEqual("aabz", _characterCounter.ToString());
        }
        
        #endregion
        
        #region FIELDS

        private CharacterCounter _characterCounter;
        
        #endregion
    }
}