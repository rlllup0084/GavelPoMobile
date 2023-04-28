using GavelPoMobile.Maui.ViewModels;

namespace GavelPoMobile.Maui.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class IncomingPage : ContentPage
{
	public IncomingPage()
	{
		InitializeComponent();
        BindingContext = ViewModel = new IncomingViewModel();
    }

	IncomingViewModel ViewModel { get; }

    protected override void OnAppearing() {
        base.OnAppearing();
        ViewModel.OnAppearing();
    }
}