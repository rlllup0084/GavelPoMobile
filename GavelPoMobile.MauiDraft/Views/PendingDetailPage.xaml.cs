namespace GavelPoMobile.MauiDraft.Views;

public partial class PendingDetailPage : ContentPage
{
	public PendingDetailPage(PendingDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
