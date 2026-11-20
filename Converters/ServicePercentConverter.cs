using System;
using System.Globalization;
using System.Windows.Data;

namespace CafeOrderApp.Converters;

public class ServicePercentConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is decimal fraction ? (fraction * 100).ToString("0.##", culture) : "";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (decimal.TryParse(value as string, NumberStyles.Number, culture, out decimal percent))
        {
            return percent / 100m;
        }

        return Binding.DoNothing;
    }
}
