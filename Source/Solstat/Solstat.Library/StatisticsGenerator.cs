using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Solstat.Library
{
  public class StatisticsGenerator
  {
    public SolutionStatistics Generate(string solutionFilePath)
    {
      if (string.IsNullOrEmpty(solutionFilePath))
        throw new ArgumentNullException("solutionFilePath", "Parameter 'solutionFilePath' cannot be null or empty.");

      if (!File.Exists(solutionFilePath))
        throw new ArgumentException(string.Format("File does not exist ({0})", solutionFilePath));

      var parser = new SolutionParser();
      var projects = parser.Parse(solutionFilePath);

      var statistics = new SolutionStatistics();

      CategoryFiller(projects, p => p.TargetFrameworkVersion, statistics.TargetFramework.Values);

      foreach (var p in projects)
        statistics.Projects.Add(p);

      return statistics;
    }

    private void CategoryFiller(IList<Project> projects, Func<Project, string> projectPropertySelector, IList<CategoryValue> list)
    {
      var summary = projects.GroupBy(projectPropertySelector).Select(g => new { Key = g.Key, Count = g.Count() });
      var total = summary.Sum(t => t.Count);


      foreach (var t in summary)
      {
        list.Add(new CategoryValue() { Value = t.Key, Count = t.Count, Ratio = (decimal)t.Count / (decimal)total });
      }
    }
  }
}
