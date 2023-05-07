using GavelPoMobile.Maui.ViewModels;

namespace GavelPoMobile.Maui.Views;

public partial class OtherPurchaseOrderDetailsPage : ContentPage {
    public OtherPurchaseOrderDetailsPage() {
        InitializeComponent();
        var viewModel = new OtherPurchaseOrderDetailsViewModel();
        BindingContext = viewModel;
        this.Disappearing += PurchaseOrderDetailsPage_Disappearing;
    }

    private void PurchaseOrderDetailsPage_Disappearing(object sender, EventArgs e) {

    }

    private void grid_CustomCellAppearance(object sender, DevExpress.Maui.DataGrid.CustomCellAppearanceEventArgs e) {
        //DataGridView dataGridView = (DataGridView)sender;
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
            e.FontSize = 14;
            e.FontAttributes = FontAttributes.Italic;
        }
    }
}