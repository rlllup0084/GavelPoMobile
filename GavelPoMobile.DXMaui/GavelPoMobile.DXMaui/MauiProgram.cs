using CommunityToolkit.Maui;
using DevExpress.Maui;

namespace GavelPoMobile.DXMaui; 
public static class MauiProgram {
    public static MauiApp CreateMauiApp() {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseDevExpress(useLocalization: true)
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts => {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("roboto-regular.ttf", "Roboto");
                fonts.AddFont("roboto-medium.ttf", "Roboto-Medium");
                fonts.AddFont("roboto-bold.ttf", "Roboto-Bold");
                fonts.AddFont("univia-pro-regular.ttf", "Univia-Pro");
                fonts.AddFont("univia-pro-medium.ttf", "Univia-Pro Medium");
            });

        return builder.Build();
    }
}