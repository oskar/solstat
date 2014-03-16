using System.Windows.Controls;

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

    public SolstatControlViewModel ViewModel
    {
      get { return (SolstatControlViewModel)DataContext; }
      set { DataContext = value; }
    }
  }
}
