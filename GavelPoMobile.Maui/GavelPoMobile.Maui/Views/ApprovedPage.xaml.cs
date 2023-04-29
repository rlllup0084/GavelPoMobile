using GavelPoMobile.Maui.ViewModels;

namespace GavelPoMobile.Maui.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class ApprovedPage : ContentPage
{
	public ApprovedPage()
	{
		InitializeComponent();
        BindingContext = new ApprovedViewModel();
    }
}