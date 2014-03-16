using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace Solstat.Library.Tests
{
  [TestFixture]
  public class SolutionParserFixture
  {
    private readonly string solutionFile_ = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data",
                                                         "SolstatTestData.sln");

    [Test]
    public void Should_throw_exception_when_solution_file_argument_is_null_or_empty()
    {
      var parser = new SolutionParser();
      Assert.Throws<ArgumentNullException>(() => parser.Parse(null));
      Assert.Throws<ArgumentNullException>(() => parser.Parse(""));
    }

    [Test]
    public void Should_contain_three_projects()
    {
      var parser = new SolutionParser();
      var projects = parser.Parse(solutionFile_);
      Assert.IsNotNull(projects);
      Assert.That(projects.Count, Is.EqualTo(3));
    }

    [Test]
    public void Should_contain_one_wpf_project()
    {
      var parser = new SolutionParser();
      var projects = parser.Parse(solutionFile_);
      Assert.IsNotNull(projects);

      var wpfProject = projects.Single(p => p.Name == "WpfApplication1");
      Assert.That(wpfProject.TargetFrameworkVersion, Is.EqualTo(TargetFrameworkVersion.NetFramework45));
    }
  }
}
