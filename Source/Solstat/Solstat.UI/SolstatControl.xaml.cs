using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using Solstat.Library;

namespace Solstat.UI
{
  /// <summary>
  /// Interaction logic for SolstatControl.xaml
  /// </summary>
  public partial class SolstatControl : UserControl
  {
    public SolstatControl()
    {
      InitializeComponent();
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
      var dialog = new OpenFileDialog();
      dialog.DefaultExt = ".sln";
      if (dialog.ShowDialog().GetValueOrDefault())
      {
        var path = dialog.FileName;
        var parser = new SolutionParser(path);
        var projects = parser.Parse();

        var warnAsError = projects.Count(p => p.WarnAsError);
        //var notWarnAsError = projects.Count - warnAsError;

        pieWarnAsError.Slice = warnAsError / projects.Count;
      }
    }
  }
}
