namespace GavelPoMobile.Maui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("FontAwesome6FreeBrands.otf", "FontAwesomeBrands");
				fonts.AddFont("FontAwesome6FreeRegular.otf", "FontAwesomeRegular");
				fonts.AddFont("FontAwesome6FreeSolid.otf", "FontAwesomeSolid");
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<HomeViewModel>();

		builder.Services.AddSingleton<HomePage>();

		builder.Services.AddTransient<SampleDataService>();
		builder.Services.AddTransient<IncomingDetailViewModel>();
		builder.Services.AddTransient<IncomingDetailPage>();

		builder.Services.AddSingleton<IncomingViewModel>();

		builder.Services.AddSingleton<IncomingPage>();

		builder.Services.AddTransient<SampleDataService>();
		builder.Services.AddTransient<PendingDetailViewModel>();
		builder.Services.AddTransient<PendingDetailPage>();

		builder.Services.AddSingleton<PendingViewModel>();

		builder.Services.AddSingleton<PendingPage>();

		builder.Services.AddTransient<SampleDataService>();
		builder.Services.AddTransient<HistoryDetailViewModel>();
		builder.Services.AddTransient<HistoryDetailPage>();

		builder.Services.AddSingleton<HistoryViewModel>();

		builder.Services.AddSingleton<HistoryPage>();

		builder.Services.AddSingleton<AccountViewModel>();

		builder.Services.AddSingleton<AccountPage>();

		return builder.Build();
	}
}
