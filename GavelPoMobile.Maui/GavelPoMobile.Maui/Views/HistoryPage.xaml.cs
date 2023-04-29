using GavelPoMobile.Maui.ViewModels;

namespace GavelPoMobile.Maui.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class HistoryPage : ContentPage
{
	public HistoryPage()
	{
		InitializeComponent();
        BindingContext = new HistoryViewModel();
    }
}