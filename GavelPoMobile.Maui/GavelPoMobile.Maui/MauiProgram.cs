using DevExpress.Maui;

namespace GavelPoMobile.Maui;
public static class MauiProgram {
    public static MauiApp CreateMauiApp() {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseDevExpress(useLocalization: true)
            .ConfigureFonts(fonts => {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("univia-pro-regular.ttf", "Univia-Pro");
                fonts.AddFont("roboto-bold.ttf", "Roboto-Bold");
                fonts.AddFont("roboto-regular.ttf", "Roboto");
            });

        return builder.Build();
    }
}