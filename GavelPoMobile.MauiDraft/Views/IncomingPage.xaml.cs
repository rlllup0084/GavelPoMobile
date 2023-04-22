namespace GavelPoMobile.MauiDraft.Views;

public partial class IncomingPage : ContentPage
{
	IncomingViewModel ViewModel;

	public IncomingPage(IncomingViewModel viewModel)
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
