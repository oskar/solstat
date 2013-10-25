using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Solstat.Library.Tests
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

    [TestMethod]
    public void ShouldReturnListOfProjects()
    {
      var solutionFile = FileHelper.FindSolutionFile(Environment.CurrentDirectory);

      var parser = new SolutionParser(solutionFile);
      var projects = parser.Parse();

      Assert.IsNotNull(projects);
    }
  }
}
