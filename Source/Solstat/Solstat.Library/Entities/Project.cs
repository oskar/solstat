namespace Solstat.Library
{
  public class Project
  {
    public string Name { get; set; }
    public string Path { get; set; }
    public TargetFrameworkVersion TargetFrameworkVersion { get; set; }
    public bool WarnAsError { get; set; }
  }
}
