using System;
using System.Globalization;
using System.Windows.Data;

namespace Solstat.UI
{
  public class FractionToPercentageConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      var fraction = (double)value;
      var percentage = (int)Math.Round(fraction * 100);

      return string.Format("{0} %", percentage);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
