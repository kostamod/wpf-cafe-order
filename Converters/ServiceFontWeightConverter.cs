using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CafeOrderApp.Converters;

public class ServiceFontWeightConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is decimal fraction && fraction > 0
            ? FontWeights.Bold
            : FontWeights.Normal;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}
