using System.Globalization;

namespace GavelPoMobile.Maui; 
public partial class PlatformLocale {
    public partial string GetPlatformLocale() {
        return CultureInfo.CurrentCulture.Name;
    }
}

