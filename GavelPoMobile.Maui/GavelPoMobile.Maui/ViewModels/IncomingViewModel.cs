using GavelPoMobile.Maui.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace GavelPoMobile.Maui.ViewModels;
public class IncomingViewModel : BaseViewModel {
    int nextPage = 1;
    int totalPages = 1;
    public IncomingViewModel() {
        Title = "Incoming";
        Items = new ObservableCollection<PurchaseOrderData>();
        LoadMoreCommand = new Command(ExecuteLoadMoreCommand);
        OpenPurchaseOrder = new Command<PurchaseOrderData>(ExecuteOpenPurchaseOrder);
    }

    async void ExecuteOpenPurchaseOrder(PurchaseOrderData purchaseOrder) {
        //Console.WriteLine(purchaseOrder.Id);
        await Navigation.NavigateToAsync<PurchaseOrderViewModel>(purchaseOrder.Id.ToString());
    }

    public Command<PurchaseOrderData> OpenPurchaseOrder { get; }

    void ExecuteLoadMoreCommand() {
        Task.Run(() => {
            Thread.Sleep(1000);
            if (nextPage <= totalPages) {
                LoadData(nextPage);
            }
            IsRefreshing = false;
        });
    }
    bool isRefreshing = false;
    public bool IsRefreshing {
        get => this.isRefreshing;
        set => SetProperty(ref this.isRefreshing, value);
    }

    public ObservableCollection<PurchaseOrderData> Items { get; private set; }

    ICommand loadMoreCommand = null;
    public ICommand LoadMoreCommand {
        get => this.loadMoreCommand;
        set => SetProperty(ref this.loadMoreCommand, value);
    }

    async void LoadData(int page) {
        var response = await PurchaseOrderService.GetPurchaseOrderByStatus(0, page, 20);

        try {
            var pagedPurchaseOrders = JsonConvert.DeserializeObject<PagedPurchaseOrders>(response);
            totalPages = pagedPurchaseOrders.TotalPages;
            foreach (var item in pagedPurchaseOrders.Results) {
                Items.Add(item);
            }
            nextPage++;
        } catch (Exception) {
            await Shell.Current.DisplayAlert("Technical Difficulties", "Please ask your system administrator for assistance or try again later.", "OK");
        }
    }
}