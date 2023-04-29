using GavelPoMobile.Maui.ViewModels;

namespace GavelPoMobile.Maui.Views;

public partial class DisapprovedPage : ContentPage
{
	public DisapprovedPage()
	{
		InitializeComponent();
        BindingContext = new DisapprovedViewModel();
    }
}