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

    private readonly string _solutionFileName;

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

    public SolutionParser(string solutionFileName)
    {
      if (string.IsNullOrEmpty(solutionFileName))
      {
        throw new ArgumentNullException("solutionFileName", "solutionFileName can not be null or empty.");
      }

      if (s_SolutionParser == null)
      {
        throw new InvalidOperationException("Can not find type 'Microsoft.Build.Construction.SolutionParser' are you missing a assembly reference to 'Microsoft.Build.dll'?");
      }

      _solutionFileName = solutionFileName;
    }

    public List<SolutionProject> Parse()
    {
      if (!File.Exists(_solutionFileName))
      {
        throw new ArgumentException("File does not exists: " + _solutionFileName);
      }

      var solutionParser = s_SolutionParser.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic).First().Invoke(null);
      using (var streamReader = new StreamReader(_solutionFileName))
      {
        s_SolutionParser_solutionReader.SetValue(solutionParser, streamReader, null);
        s_SolutionParser_parseSolution.Invoke(solutionParser, null);
      }
      var projects = new List<SolutionProject>();
      var array = (Array)s_SolutionParser_projects.GetValue(solutionParser, null);
      for (int i = 0; i < array.Length; i++)
      {
        projects.Add(new SolutionProject(array.GetValue(i)));
      }

      return projects;
    }

    public List<Project> ParseRealProjects()
    {
      throw new NotImplementedException();
    }
  }
}
