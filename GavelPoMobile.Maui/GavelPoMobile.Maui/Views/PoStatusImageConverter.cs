using System.Globalization;

namespace GavelPoMobile.Maui.Views;

public class PoStatusImageConverter : IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        if (value is int status) {
            switch (status) {
                case 0:
                    return "incoming_1.png";
                case 1:
                    return "approve_1.png";
                case 2:
                    return "approve_1.png";
                case 3:
                    return "approve_1.png";
                case 4:
                    return "disapprove_1.png";
                case 5:
                    return "pending_1.png";
            }
        }
        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        return null;
    }
}
