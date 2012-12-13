using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solstat.Library;

namespace Solstat.Tests
{
    [TestClass]
    public class SolutionParserTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowExceptionWhenSolutionFileArgumentIsNull()
        {
            var parser = new SolutionParser(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowExceptionWhenSolutionFileArgumentIsEmpty()
        {
            var parser = new SolutionParser("");
        }
    }
}
