using System.Windows;
using System.Windows.Forms;
using Solstat.Library;

namespace Solstat.VSExtension
{
  /// <summary>
  /// Interaction logic for MyControl.xaml
  /// </summary>
  public partial class MyControl
  {
    public MyControl()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, RoutedEventArgs e)
    {
      System.Windows.MessageBox.Show("Solstat", "Solstat");

      using (var fileBrowserDialog = new OpenFileDialog())
      {
        fileBrowserDialog.ShowDialog();
      }
    }
  }
}
