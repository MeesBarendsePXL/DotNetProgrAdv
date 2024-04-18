using System;
using System.Globalization;
using System.Windows.Data;

namespace Exercise2.Converters
{
    public class RatingStarsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            return new String('*',(int)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
