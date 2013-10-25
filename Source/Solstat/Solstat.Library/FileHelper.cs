using System;
using System.IO;

namespace Solstat.Library
{
  public static class FileHelper
  {
    public static string FindSolutionFile(string directory)
    {
      if (string.IsNullOrEmpty(directory))
        throw new ArgumentNullException("directory", "Parameter 'directory' cannot be null or empty");

      return FindFileByPatternUpwards("*.sln", directory);
    }

    private static string FindFileByPatternUpwards(string filePattern, string startDirectory)
    {
      if (!Directory.Exists(startDirectory))
        return null;

      var file = FindFirstFileByPattern(filePattern, startDirectory);

      if (!string.IsNullOrEmpty(file))
        return file;

      var parentDirectory = Directory.GetParent(startDirectory);
      if (parentDirectory == null)
        return null;

      return FindFileByPatternUpwards(filePattern, parentDirectory.FullName);
    }

    private static string FindFirstFileByPattern(string filePattern, string directory)
    {
      var files = Directory.GetFiles(directory, filePattern);
      if (files.Length == 0)
        return null;

      return files[0];
    }
  }
}
