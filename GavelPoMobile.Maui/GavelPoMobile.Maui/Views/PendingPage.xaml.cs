using GavelPoMobile.Maui.ViewModels;

namespace GavelPoMobile.Maui.Views;

public partial class PendingPage : ContentPage
{
	public PendingPage()
	{
		InitializeComponent();
        BindingContext = new PendingViewModel();
    }
}