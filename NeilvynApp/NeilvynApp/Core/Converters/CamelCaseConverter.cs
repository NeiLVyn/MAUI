using System;
using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace NeilvynApp.Core.Converters
{
    public class CamelCaseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string description)
            {
                return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(description.ToLower());
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string description)
            {
                return CultureInfo.CurrentCulture.TextInfo.ToLower(description.ToLower());
            }
            return value;
        }
    }
}
