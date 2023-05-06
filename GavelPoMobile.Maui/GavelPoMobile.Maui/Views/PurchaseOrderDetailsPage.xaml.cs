using DevExpress.Maui.DataGrid;
using GavelPoMobile.Maui.Models;
using GavelPoMobile.Maui.ViewModels;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GavelPoMobile.Maui.Views;

public partial class PurchaseOrderDetailsPage : ContentPage
{
	public PurchaseOrderDetailsPage()
	{
		InitializeComponent();
        var viewModel = new PurchaseOrderDetailsViewModel();
        BindingContext = viewModel;
        this.Disappearing+= PurchaseOrderDetailsPage_Disappearing;
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

    private void OnHold(object sender, SwipeItemTapEventArgs e) {

    }

    private void OnRelease(object sender, SwipeItemTapEventArgs e) {

    }

    private void grid_Tap(object sender, DataGridGestureEventArgs e) {
        DataGridView dataGridView = (DataGridView)sender;
        if (e.Item == null || dataGridView.EditorShowMode == EditorShowMode.Tap)
            return;
    }

    private void grid_ValidateCell(object sender, ValidateCellEventArgs e) {
        if (e.FieldName == "Remarks" && !string.IsNullOrWhiteSpace((string)e.NewValue)) {
        }
    }

    private void grid_EditorShowing(object sender, EditorShowingEventArgs e) {
        if (e.FieldName == "Remarks") {
            object cellValue = grid.GetCellValue(e.RowHandle, grid.Columns["Remarks"]);
            if (cellValue != null && cellValue.ToString() == "Has no remarks..." ) {
                PurchaseOrderDetail item = (PurchaseOrderDetail)e.Item;
                item.Remarks = "";
            }
        } else { e.Cancel = true; }
    }

    private void grid_PropertyChanged(object sender, PropertyChangedEventArgs e) {
    }

}