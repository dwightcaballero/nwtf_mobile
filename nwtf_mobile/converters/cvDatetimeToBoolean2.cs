using System;
using System.Globalization;
using Xamarin.Forms;

namespace nwtf_mobile.converters
{
    class cvDatetimeToBoolean2 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return (DateTime)value == DateTime.MinValue;
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
