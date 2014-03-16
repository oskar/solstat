using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Solstat.Library
{
  public class SolutionParser
  {
    //internal class SolutionParser
    //Name: Microsoft.Build.Construction.SolutionParser
    //Assembly: Microsoft.Build, Version=4.0.0.0

    static readonly Type s_SolutionParser;
    static readonly PropertyInfo s_SolutionParser_solutionReader;
    static readonly MethodInfo s_SolutionParser_parseSolution;
    static readonly PropertyInfo s_SolutionParser_projects;

    static SolutionParser()
    {
      s_SolutionParser = Type.GetType("Microsoft.Build.Construction.SolutionParser, Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", false, false);
      if (s_SolutionParser != null)
      {
        s_SolutionParser_solutionReader = s_SolutionParser.GetProperty("SolutionReader", BindingFlags.NonPublic | BindingFlags.Instance);
        s_SolutionParser_projects = s_SolutionParser.GetProperty("Projects", BindingFlags.NonPublic | BindingFlags.Instance);
        s_SolutionParser_parseSolution = s_SolutionParser.GetMethod("ParseSolution", BindingFlags.NonPublic | BindingFlags.Instance);
      }
    }

    public SolutionParser()
    {
      if (s_SolutionParser == null)
      {
        throw new InvalidOperationException("Can not find type 'Microsoft.Build.Construction.SolutionParser' are you missing a assembly reference to 'Microsoft.Build.dll'?");
      }
    }

    public List<Project> Parse(string solutionFilePath)
    {
      var solutionProjects = ParseSolutionProjects(solutionFilePath);
      var solutionDirectory = Path.GetDirectoryName(solutionFilePath);

      var realProjects = new List<Project>();
      var projectParser = new ProjectParser();

      // TODO: Filter solutionProjects based on project type? Only parse "real" projects?
      foreach (var solutionProject in solutionProjects)
      {
        var projectFilePath = Path.Combine(solutionDirectory, solutionProject.RelativePath);
        var realProject = projectParser.Parse(projectFilePath, solutionProject.ProjectName);
        realProjects.Add(realProject);
      }

      return realProjects;
    }

    private List<SolutionProject> ParseSolutionProjects(string solutionFilePath)
    {
      if (string.IsNullOrEmpty(solutionFilePath))
      {
        throw new ArgumentNullException("solutionFilePath", "Solution file path cannot be null or empty.");
      }

      if (!File.Exists(solutionFilePath))
      {
        throw new ArgumentException("Solution file does not exists: " + solutionFilePath);
      }

      var solutionParser = s_SolutionParser.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic).First().Invoke(null);
      using (var streamReader = new StreamReader(solutionFilePath))
      {
        s_SolutionParser_solutionReader.SetValue(solutionParser, streamReader, null);
        s_SolutionParser_parseSolution.Invoke(solutionParser, null);
      }
      var solutionProjects = new List<SolutionProject>();
      var array = (Array)s_SolutionParser_projects.GetValue(solutionParser, null);
      for (int i = 0; i < array.Length; i++)
      {
        solutionProjects.Add(new SolutionProject(array.GetValue(i)));
      }

      return solutionProjects;
    }
  }
}
