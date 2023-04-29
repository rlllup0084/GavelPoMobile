using DevExpress.Maui.DataGrid;
using GavelPoMobile.Maui.ViewModels;

namespace GavelPoMobile.Maui.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class IncomingPage : ContentPage
{
	public IncomingPage()
	{
		InitializeComponent();
        BindingContext = new IncomingViewModel();
    }
}