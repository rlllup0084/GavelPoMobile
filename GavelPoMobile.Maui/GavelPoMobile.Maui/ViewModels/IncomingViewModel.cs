using GavelPoMobile.Maui.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace GavelPoMobile.Maui.ViewModels;
public class IncomingViewModel : BaseViewModel {
    public IncomingViewModel() {
        Title = "Incoming";
        Items = new ObservableCollection<PurchaseOrderData>();
    }

    public ObservableCollection<PurchaseOrderData> Items { get; private set; }

    async public void OnAppearing() {
        var response = await PurchaseOrderService.GetPurchaseOrderByStatus(1, 1, 20);

        try {
            var pagedPurchaseOrders = JsonConvert.DeserializeObject<PagedPurchaseOrders>(response);
            foreach (var item in pagedPurchaseOrders.Results) {
                Items.Add(item);
            }
        } catch (Exception) {
            await Shell.Current.DisplayAlert("Technical Difficulties", "Please ask your system administrator for assistance or try again later.", "OK");
        }
    }
}
