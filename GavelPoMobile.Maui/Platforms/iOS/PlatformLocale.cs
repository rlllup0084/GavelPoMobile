using Foundation;
namespace GavelPoMobile.Maui {
    public partial class PlatformLocale {
        public partial string GetPlatformLocale() {
            return NSLocale.PreferredLanguages[0];
        }
    }
}

