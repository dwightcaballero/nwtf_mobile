using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using nwtf_mobile_bl;

namespace nwtf_mobile.converters
{
    class cvEnumIntToDescription : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value!= null)
            {
                return systemconst.getClaimantDescription((int)value);
            }
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return systemconst.getClaimantNumber(value.ToString());
            }
            return "";
        }
    }
}
