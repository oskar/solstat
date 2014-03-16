using System.ComponentModel;

namespace Solstat.UI
{
  public class ViewModelBase : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
      var temp = PropertyChanged;
      if (temp != null)
      {
        temp(this, new PropertyChangedEventArgs(propertyName));
      }
    }
  }
}
