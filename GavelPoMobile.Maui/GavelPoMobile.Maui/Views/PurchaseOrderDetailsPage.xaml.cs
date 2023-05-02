using GavelPoMobile.Maui.ViewModels;

namespace GavelPoMobile.Maui.Views;

public partial class PurchaseOrderDetailsPage : ContentPage
{
	public PurchaseOrderDetailsPage()
	{
		InitializeComponent();
        BindingContext = new PurchaseOrderDetailsViewModel();
    }

    private void grid_CustomCellAppearance(object sender, DevExpress.Maui.DataGrid.CustomCellAppearanceEventArgs e) {

    }
}