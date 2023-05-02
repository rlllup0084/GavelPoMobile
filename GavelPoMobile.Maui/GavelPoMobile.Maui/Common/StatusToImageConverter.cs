using System.Globalization;

namespace GavelPoMobile.Maui.Common;

public class StatusToImageConverter : IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        if (value is int status) {
            switch (status) {
                case 0:
                    return "hold.png"; // replace with your current status image file name
                case 1:
                    return "release.png"; // replace with your approve status image file name
                                          // add more cases for other status values if needed
            }
        }
        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        throw new NotSupportedException();
    }
}
