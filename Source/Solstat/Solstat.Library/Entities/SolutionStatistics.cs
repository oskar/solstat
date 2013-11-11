using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solstat.Library
{
    public class SolutionStatistics
    {
        private readonly IList<Project> _projects = new List<Project>();

        public SolutionStatistics()
        {
            TargetFramework = new Category("Target Framework");
        }

        public IList<Project> Projects
        {
            get { return _projects; }
        }

        public Category TargetFramework { get; private set; }
    }
}
