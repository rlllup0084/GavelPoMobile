using Microsoft.Maui.Controls;
using System;
using System.Globalization;

namespace DemoCenter.Maui.Views {
    public class UpperCaseConverter : IValueConverter {
        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo culture) {
            return value?.ToString().ToUpperInvariant();
        }

        public object ConvertBack(object value, Type targetType,
                                  object parameter, CultureInfo culture) {
            return value?.ToString().ToLowerInvariant();
        }
    }

    public class CallTypeToIconConverter : IValueConverter {
        public object Convert(object value, Type targetType,
                             object parameter, CultureInfo culture) {
            return String.Format("demotabview{0}", value.ToString().ToLowerInvariant());
        }

        public object ConvertBack(object value, Type targetType,
                                  object parameter, CultureInfo culture) {
            return null;
        }
    }
}
