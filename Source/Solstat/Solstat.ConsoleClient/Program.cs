using System;
using Solstat.Library;

namespace Solstat.ConsoleClient
{
  class Program
  {
    static void Main(string[] args)
    {
      var sol = new SolutionParser();
      var projects = sol.Parse(@"..\..\..\Solstat.sln");

      Console.WriteLine("Projects in solution:");

      foreach (var project in projects)
      {
        Console.WriteLine(string.Format("{0} ({1})", project.Name, project.Path));
      }

      Console.WriteLine("Total: " + projects.Count);

      Console.ReadLine();
    }
  }
}
