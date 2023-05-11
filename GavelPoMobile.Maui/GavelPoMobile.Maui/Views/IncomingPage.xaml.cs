using DevExpress.Maui.DataGrid;
using GavelPoMobile.Maui.ViewModels;

namespace GavelPoMobile.Maui.Views;

public partial class IncomingPage : ContentPage {
    public IncomingPage() {
        InitializeComponent();
        BindingContext = new IncomingViewModel();
    }

    private void grid_CustomCellAppearance(object sender, CustomCellAppearanceEventArgs e) {
        e.FontSize = 12;
        if (e.RowHandle % 2 == 0)
            e.BackgroundColor = Color.FromArgb("#F7F7F7");
        if (e.FieldName == "Vendor") {
            e.FontAttributes = FontAttributes.Bold;
        }
        if (e.FieldName == "Total") {
            e.FontSize = 14;
            e.FontAttributes = FontAttributes.Bold;
        }
    }

    private void OnShowPurchaseInfo(object sender, SwipeItemTapEventArgs e) {

    }

    private void OnApprove(object sender, SwipeItemTapEventArgs e) {

    }

    private void OnDisapprove(object sender, SwipeItemTapEventArgs e) {

    }

    private void OnPending(object sender, SwipeItemTapEventArgs e) {

    }
}