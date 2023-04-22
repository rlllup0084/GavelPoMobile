namespace GavelPoMobile.MauiDraft.Views;

public partial class PendingPage : ContentPage
{
	PendingViewModel ViewModel;

	public PendingPage(PendingViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = ViewModel = viewModel;
	}

	protected override async void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);

		await ViewModel.LoadDataAsync();
	}
}
