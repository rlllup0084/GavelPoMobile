using GavelPoMobile.Maui.ViewModels;

namespace GavelPoMobile.Maui.Views;

public partial class PurchaseOrderDetailsPage : ContentPage
{
	public PurchaseOrderDetailsPage()
	{
		InitializeComponent();
        BindingContext = new PurchaseOrderDetailsViewModel();
    }
}