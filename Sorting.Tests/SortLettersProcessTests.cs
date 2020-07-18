using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestUtilities;

namespace Sorting.Tests
{
    [TestClass]
    public class SortLettersProcessTests
    {
        #region INITIALIZATION
        
        [TestInitialize]
        public void Initialize()
        {
            _process = new SortLettersProcess();
        }
        
        #endregion
        
        #region TESTS

        [TestMethod]
        [Description("The value of the text argument is null")]
        public void Perform1()
        {
            Assert.AreEqual("", _process.Perform(null));
        }
        
        [TestMethod]
        [Description("The value of the text argument is the empty string")]
        public void Perform2()
        {
            Assert.AreEqual("", _process.Perform(""));
        }
        
        [TestMethod]
        [Description("The text argument is a one character string")]
        public void Perform3()
        {
            Assert.AreEqual("g", _process.Perform("G"));
        }
        
        [TestMethod]
        [Description("The text argument is a multi-character string")]
        public void Perform4()
        {
            Assert.AreEqual("aaaaaabccdddeeeeeeeeeeeeeefgghhhhhhhhiiiiiiikmmnnnnnnnnooooooooprrrrrrrssstttttttttttuvwwwy", 
                _process.Perform("Perfection is achieved not when there is nothing more to add, but rather when there is nothing more to take away."));
        }

        [TestMethod]
        [Description("Exclude symbols, punctuation and numbers")]
        public void ExtractLettersFromString1()
        {
            var result = MethodUtilities.CallInternal<string>(_process, "ExtractLettersFromString", "1234567890-=`~!@#$%^&*()_+ ,.<>/?\"'|\\}]{{><')");

            Assert.AreEqual("", result);
        }
        
        [TestMethod]
        [Description("Include letters")]
        public void ExtractLettersFromString2()
        {
            string input = "ABCdefGHIjklMNOpqrSTUvwxYZ";
            
            var result = MethodUtilities.CallInternal<string>(_process, "ExtractLettersFromString", input);
            
            Assert.AreEqual(input, result);
        }
        
        #endregion
        
        #region FIELDS
        
        private SortLettersProcess _process;
        
        #endregion
    }
}