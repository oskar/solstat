// Guids.cs
// MUST match guids.h
using System;

namespace Solstat.VSExtension
{
  static class GuidList
  {
    public const string guidSolstat_VSExtensionPkgString = "ddc3fdd4-af25-4400-8afa-6b0587dc80b6";
    public const string guidSolstat_VSExtensionCmdSetString = "08e7ac66-a417-418a-9c34-d24e30f3b871";
    public const string guidToolWindowPersistanceString = "49302470-941a-473c-a68d-24915d244eac";

    public static readonly Guid guidSolstat_VSExtensionCmdSet = new Guid(guidSolstat_VSExtensionCmdSetString);
  };
}
