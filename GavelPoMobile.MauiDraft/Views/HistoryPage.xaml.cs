namespace GavelPoMobile.MauiDraft.Views;

public partial class HistoryPage : ContentPage
{
	HistoryViewModel ViewModel;

	public HistoryPage(HistoryViewModel viewModel)
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
