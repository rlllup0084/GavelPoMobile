using GavelPoMobile.Maui.ViewModels;

namespace GavelPoMobile.Maui.Views;

public partial class OtherPurchaseOrderPage : ContentPage
{
	public OtherPurchaseOrderPage()
	{
		InitializeComponent();
        BindingContext = new OtherPurchaseOrderViewModel();
    }
}