using NUnit.Framework;
using Solstat.Library;
using System;
using System.Linq;

namespace Solstat.Tests
{
  [TestFixture]
  public class StatisticsGeneratorFixture
  {
    [Test]
    public void ShouldGenerateStatistics()
    {
      var generator = new StatisticsGenerator();
      var statistics = generator.Generate(FileHelper.FindSolutionFile(Environment.CurrentDirectory));

      Assert.IsNotNull(statistics);

      Assert.IsNotNull(statistics.Projects);
      Assert.IsTrue(statistics.Projects.Count > 0);

      Assert.IsNotNull(statistics.TargetFramework);
      Assert.IsNotNull(statistics.TargetFramework.Values);
      Assert.IsTrue(statistics.TargetFramework.Values.Count > 0);

      Assert.IsTrue(statistics.TargetFramework.Values.Sum(c => c.Ratio) == 1);
      Assert.IsTrue(statistics.TargetFramework.Values.Sum(c => c.Count) == statistics.Projects.Count);

      Console.WriteLine(statistics);
    }
  }
}
