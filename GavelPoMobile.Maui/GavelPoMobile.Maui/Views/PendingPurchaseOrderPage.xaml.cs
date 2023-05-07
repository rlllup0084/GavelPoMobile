using GavelPoMobile.Maui.ViewModels;

namespace GavelPoMobile.Maui.Views;

public partial class PendingPurchaseOrderPage : ContentPage
{
	public PendingPurchaseOrderPage()
	{
		InitializeComponent();
        BindingContext = new PendingPurchaseOrderViewModel();
    }
}