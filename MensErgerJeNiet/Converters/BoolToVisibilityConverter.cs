using System;
using System.Globalization;
using System.Windows.Data;

namespace MensErgerJeNiet.Converters
{
    [ValueConversion(typeof(bool), typeof(string))]
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolean)
            {
                if (boolean == true)
                {
                    return "Visible";
                }
                else
                {
                    return "Hidden";
                }
            }
            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string stringvalue)
            {
                if (stringvalue == "Visible")
                {
                    return true;
                }
                if (stringvalue == "Hidden")
                {
                    return false;
                }
            }
            return default(bool);
        }
    }
}
