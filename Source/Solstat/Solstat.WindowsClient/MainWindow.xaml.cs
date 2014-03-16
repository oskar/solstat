using System.Windows;

namespace Solstat.WindowsClient
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void SolstatControl_Loaded(object sender, RoutedEventArgs e)
    {
      SolstatControl.ViewModel = new UI.SolstatControlViewModel();
    }
  }
}
