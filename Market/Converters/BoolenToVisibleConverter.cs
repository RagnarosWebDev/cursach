using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Market.Converters;

public class BoolenToVisibleConverter: IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (!(value is bool))
        {
            return Visibility.Collapsed;
        }
        return (bool)value ? Visibility.Visible : Visibility.Collapsed;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}