using System.Web;

namespace GavelPoMobile.Maui.ViewModels;
public class PurchaseOrderDetailsViewModel : BaseViewModel, IQueryAttributable {
    public async void ApplyQueryAttributes(IDictionary<string, object> query) {
        string id = HttpUtility.UrlDecode(query["id"] as string);
        await LoadPurchaseOrderDetails(id);
    }

    private async Task LoadPurchaseOrderDetails(string id) {
        await Task.CompletedTask;
    }
}
