using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Solstat.Library.Tests
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
