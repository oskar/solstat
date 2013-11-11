using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solstat.Library
{
    public enum SolutionProjectType
    {
        Unknown,
        KnownToBeMSBuildFormat,
        SolutionFolder,
        WebProject,
        WebDeploymentProject,
        EtpSubProject
    }
}
