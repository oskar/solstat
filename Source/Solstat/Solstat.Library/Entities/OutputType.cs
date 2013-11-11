using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Solstat.Library
{
    public enum OutputType
    {
        [Description("None")]
        None,

        [Description("Class Library")]
        ClassLibrary,

        [Description("Console Application")]
        ConsoleApplication,

        [Description("Windows Application")]
        WindowsApplication
    }
}
