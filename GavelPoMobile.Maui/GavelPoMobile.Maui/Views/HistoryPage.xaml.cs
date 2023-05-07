using DevExpress.Maui.DataGrid;
using GavelPoMobile.Maui.ViewModels;

namespace GavelPoMobile.Maui.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class HistoryPage : ContentPage
{
	public HistoryPage()
	{
		InitializeComponent();
        BindingContext = new HistoryViewModel();
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
}