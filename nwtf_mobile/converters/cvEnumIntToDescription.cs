using nwtf_mobile_bl;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace nwtf_mobile.converters
{
    class cvEnumIntToDescription : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (parameter.ToString() == "amountType")
                {
                    return systemconst.getAmountTypeDescription((int)value);
                }
                else if (parameter.ToString() == "payeeType")
                {
                    return systemconst.getPayeeTypeDescription((int)value);
                }
                else
                {
                    return systemconst.getClaimantDescription((int)value);
                }
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
