using GavelPoMobile.Maui.ViewModels;

namespace GavelPoMobile.Maui.Views;

public partial class PurchaseOrderPage : ContentPage
{
	public PurchaseOrderPage()
	{
		InitializeComponent();
		BindingContext = new PurchaseOrderViewModel();
	}
}