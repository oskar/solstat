using System;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace Solstat.Library.Tests
{
  [TestFixture]
  public class SolutionParserTests
  {
    private readonly string solutionFile_ = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data",
                                                         "SolstatTestData.sln");

    [Test]
    public void Should_throw_exception_when_solution_file_argument_is_null_or_empty()
    {
      Assert.Throws<ArgumentNullException>(() => new SolutionParser(null));
      Assert.Throws<ArgumentNullException>(() => new SolutionParser(""));
    }

    [Test]
    public void Should_contain_three_projects()
    {
      var parser = new SolutionParser(solutionFile_);
      var projects = parser.Parse();
      Assert.IsNotNull(projects);
      Assert.That(projects.Count, Is.EqualTo(3));
    }

    [Test]
    public void Should_contain_one_wpf_project()
    {
      var parser = new SolutionParser(solutionFile_);
      var projects = parser.Parse();
      Assert.IsNotNull(projects);

      var wpfProject = projects.Single(p => p.ProjectName == "WpfApplication1");
      Assert.That(wpfProject.TargetFrameworkVersion, Is.EqualTo(".NET 4.5"));
    }
  }
}
