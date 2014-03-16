using System;
using System.Diagnostics;
using System.Reflection;

namespace Solstat.Library
{
  [DebuggerDisplay("{ProjectName}, {RelativePath}, {ProjectGuid}")]
  public class SolutionProject
  {
    static readonly Type s_ProjectInSolution;
    static readonly PropertyInfo s_ProjectInSolution_ProjectName;
    static readonly PropertyInfo s_ProjectInSolution_RelativePath;
    static readonly PropertyInfo s_ProjectInSolution_ProjectGuid;
    static readonly PropertyInfo s_ProjectInSolution_ProjectType;

    static SolutionProject()
    {
      s_ProjectInSolution = Type.GetType("Microsoft.Build.Construction.ProjectInSolution, Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", false, false);
      if (s_ProjectInSolution != null)
      {
        s_ProjectInSolution_ProjectName = s_ProjectInSolution.GetProperty("ProjectName", BindingFlags.NonPublic | BindingFlags.Instance);
        s_ProjectInSolution_RelativePath = s_ProjectInSolution.GetProperty("RelativePath", BindingFlags.NonPublic | BindingFlags.Instance);
        s_ProjectInSolution_ProjectGuid = s_ProjectInSolution.GetProperty("ProjectGuid", BindingFlags.NonPublic | BindingFlags.Instance);
        s_ProjectInSolution_ProjectType = s_ProjectInSolution.GetProperty("ProjectType", BindingFlags.NonPublic | BindingFlags.Instance);
      }
    }

    public string ProjectName { get; private set; }
    public string RelativePath { get; private set; }
    public string ProjectGuid { get; private set; }
    public SolutionProjectType ProjectType { get; private set; }

    public SolutionProject(object solutionProject)
    {
      ProjectName = s_ProjectInSolution_ProjectName.GetValue(solutionProject, null) as string;
      RelativePath = s_ProjectInSolution_RelativePath.GetValue(solutionProject, null) as string;
      ProjectGuid = s_ProjectInSolution_ProjectGuid.GetValue(solutionProject, null) as string;

      if (s_ProjectInSolution_ProjectType != null)
      {
        ProjectType = (SolutionProjectType)Enum.Parse(typeof(SolutionProjectType), (s_ProjectInSolution_ProjectType.GetValue(solutionProject, null) ?? "").ToString());
      }
    }

    public override string ToString()
    {
      if (!string.IsNullOrEmpty(ProjectName))
      {
        return ProjectName;
      }

      return base.ToString();
    }
  }
}
