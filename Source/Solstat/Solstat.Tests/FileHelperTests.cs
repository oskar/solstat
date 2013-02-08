using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solstat.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solstat.Tests
{
    [TestClass]
    public class FileHelperTests
    {
        [TestMethod]
        public void ShouldReturnNothingForInvalidDirectory()
        {
            Assert.IsTrue(string.IsNullOrEmpty(FileHelper.FindSolutionFile("this-directory-does-not-exist")));
        }

        [TestMethod]
        public void ShouldFindSolutionFileStartingInCurrentDirectory()
        {
            Assert.IsFalse(string.IsNullOrEmpty(FileHelper.FindSolutionFile(Environment.CurrentDirectory)));
        }
    }
}
