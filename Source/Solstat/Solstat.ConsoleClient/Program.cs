using System;
using Solstat.Library;

namespace Solstat.ConsoleClient
{
  class Program
  {
    static void Main(string[] args)
    {
      var sol = new SolutionParser(@"..\..\..\Solstat.sln");
      var projects = sol.Parse();

      Console.WriteLine("Projects in solution:");

      foreach (var project in projects)
      {
        Console.WriteLine(string.Format("{0} ({1})", project.ProjectName, project.RelativePath));
      }

      Console.WriteLine("Total: " + projects.Count);

      Console.ReadLine();
    }
  }
}
