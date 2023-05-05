using DevExpress.Maui.DataGrid;
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
        DataGridView dataGridView = (DataGridView)sender;
        e.FontSize = 12;
        if (e.RowHandle % 2 == 0)
            e.BackgroundColor = Color.FromArgb("#F7F7F7");
        if (e.FieldName == "Description") {
            e.FontSize = 14;
            e.FontAttributes = FontAttributes.Bold;
        }
        if (e.FieldName == "Total") {
            e.FontSize = 14;
            e.FontAttributes = FontAttributes.Bold;
        }
        
        if (e.FieldName == "Remarks") {
            e.FontAttributes = FontAttributes.Italic;
        }
    }

    private void OnHold(object sender, SwipeItemTapEventArgs e) {

    }

    private void OnRelease(object sender, SwipeItemTapEventArgs e) {

    }
}