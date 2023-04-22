namespace GavelPoMobile.MauiDraft.Views;

public partial class HistoryDetailPage : ContentPage
{
	public HistoryDetailPage(HistoryDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
