namespace GavelPoMobile.Maui;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(HistoryDetailPage), typeof(HistoryDetailPage));
		Routing.RegisterRoute(nameof(PendingDetailPage), typeof(PendingDetailPage));
		Routing.RegisterRoute(nameof(IncomingDetailPage), typeof(IncomingDetailPage));
	}
}
