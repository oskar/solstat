using Microsoft.Win32;
using Solstat.Library;
using System.Linq;

namespace Solstat.UI
{
  public class SolstatControlViewModel : ViewModelBase
  {
    private int numberOfProjects_;
    private double treatWarningsAsErrors_;

    public SolstatControlViewModel()
    {
      OpenSolutionFileCommand = new RelayCommand(ExecuteOpenSolutionFileCommand, null);
    }

    public RelayCommand OpenSolutionFileCommand { get; private set; }

    public int NumberOfProjects
    {
      get { return numberOfProjects_; }
      set
      {
        if (value != numberOfProjects_)
        {
          numberOfProjects_ = value;
          OnPropertyChanged("NumberOfProjects");
        }
      }
    }

    public double TreatWarningsAsErrors
    {
      get { return treatWarningsAsErrors_; }
      set
      {
        if (value != treatWarningsAsErrors_)
        {
          treatWarningsAsErrors_ = value;
          OnPropertyChanged("TreatWarningsAsErrors");
        }
      }
    }

    private void ExecuteOpenSolutionFileCommand(object parameter)
    {
      var dialog = new OpenFileDialog();
      dialog.DefaultExt = ".sln";
      if (dialog.ShowDialog().GetValueOrDefault())
      {
        var path = dialog.FileName;
        var parser = new SolutionParser();
        var projects = parser.Parse(path);

        var warnAsError = projects.Count(p => p.WarnAsError);

        NumberOfProjects = projects.Count;
        TreatWarningsAsErrors = (double)warnAsError / projects.Count;
      }
    }
  }
}
