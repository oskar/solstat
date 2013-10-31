using System;
using NUnit.Framework;

namespace Solstat.Library.Tests
{
  [TestFixture]
  public class FileHelperFixture
  {
    [Test]
    public void Should_return_nothing_for_invalid_directory()
    {
      Assert.IsTrue(string.IsNullOrEmpty(FileHelper.FindSolutionFile("this-directory-does-not-exist")));
    }

    [Test]
    public void Should_find_solution_file_starting_in_current_directory()
    {
      Assert.IsFalse(string.IsNullOrEmpty(FileHelper.FindSolutionFile(Environment.CurrentDirectory)));
    }
  }
}
