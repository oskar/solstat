using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Solstat.Library
{
  public class ProjectParser
  {
    private readonly XNamespace msbuild = "http://schemas.microsoft.com/developer/msbuild/2003";

    public Project Parse(string projectFilePath, string projectName)
    {
      if (string.IsNullOrEmpty(projectFilePath))
        throw new ArgumentNullException("projectFilePath", "Parameter 'projectFilePath' cannot be null or empty.");

      if (!File.Exists(projectFilePath))
        throw new ArgumentException(string.Format("Project file does not exist ({0})", projectFilePath), "projectFilePath");

      var xmlDoc = XDocument.Load(projectFilePath);
      if (xmlDoc == null)
        throw new InvalidOperationException("");

      var project = new Project();

      project.Path = projectFilePath;
      project.Name = projectName;

      var version = xmlDoc
          .Element(msbuild + "Project")
          .Elements(msbuild + "PropertyGroup")
          .Elements(msbuild + "TargetFrameworkVersion")
          .Select(v => v.Value)
          .FirstOrDefault();

      project.TargetFrameworkVersion = ParseTargetFrameworkVersion(version);

      var warnAsError = xmlDoc
         .Element(msbuild + "Project")
         .Elements(msbuild + "PropertyGroup")
         .Elements(msbuild + "TreatWarningsAsErrors")
         .Select(v => v.Value)
         .FirstOrDefault();

      bool isWarnAsErrors = false;
      bool.TryParse(warnAsError, out isWarnAsErrors);

      project.WarnAsError = isWarnAsErrors;

      return project;
    }

    private TargetFrameworkVersion ParseTargetFrameworkVersion(string version)
    {
      if (string.IsNullOrEmpty(version))
        return TargetFrameworkVersion.None;

      switch (version)
      {
        case "v4.5": return TargetFrameworkVersion.NetFramework45;
        default: return TargetFrameworkVersion.Unknown;
      }
    }
  }
}
