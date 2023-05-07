using GavelPoMobile.Maui.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Web;
using System.Windows.Input;

namespace GavelPoMobile.Maui.ViewModels;
public class PendingViewModel : BaseViewModel, IQueryAttributable {
    int nextPage = 1;
    int totalPages = 1;
    bool isLoadingMore = false;
    public PendingViewModel() {
        Title = "Pending";
        Items = new ObservableCollection<PurchaseOrderData>();
        LoadMoreCommand = new Command(ExecuteLoadMoreCommand);
        PullToRefreshCommand = new Command(ExecutePullToRefreshCommand);
        OpenPurchaseOrder = new Command<PurchaseOrderData>(ExecuteOpenPurchaseOrder);
        ApprovePurchaseOrder = new Command<PurchaseOrderData>(ExecuteApprovePurchaseOrder);
        DisapprovePurchaseOrder = new Command<PurchaseOrderData>(ExecuteDisapprovePurchaseOrder);
    }

    async void ExecuteOpenPurchaseOrder(PurchaseOrderData purchaseOrder) {
        //Console.WriteLine(purchaseOrder.Id);
        await Navigation.NavigateToAsync<PurchaseOrderViewModel>(purchaseOrder.Id.ToString());
    }

    async void ExecuteApprovePurchaseOrder(PurchaseOrderData purchaseOrder) {
        var response = await PurchaseOrderService.UpdatePurchaseOrderStatus(purchaseOrder.Id, 1, purchaseOrder.Remarks);
        if (!string.IsNullOrEmpty(response)) {
            var errorData = JsonConvert.DeserializeObject<ErrorData>(response);
            return;
        }
        var itemToRemove = Items.FirstOrDefault(item => item.Id == Convert.ToInt32(purchaseOrder.Id));
        if (itemToRemove != null) {
            Items.Remove(itemToRemove);
        };
    }

    async void ExecuteDisapprovePurchaseOrder(PurchaseOrderData purchaseOrder) {
        var response = await PurchaseOrderService.UpdatePurchaseOrderStatus(purchaseOrder.Id, 4, purchaseOrder.Remarks);
        if (!string.IsNullOrEmpty(response)) {
            var errorData = JsonConvert.DeserializeObject<ErrorData>(response);
            return;
        }
        var itemToRemove = Items.FirstOrDefault(item => item.Id == Convert.ToInt32(purchaseOrder.Id));
        if (itemToRemove != null) {
            Items.Remove(itemToRemove);
        };
    }

    public Command<PurchaseOrderData> OpenPurchaseOrder { get; }

    public Command<PurchaseOrderData> ApprovePurchaseOrder { get; }

    public Command<PurchaseOrderData> DisapprovePurchaseOrder { get; }

    void ExecuteLoadMoreCommand() {
        if (isLoadingMore) {
            return;
        }

        isLoadingMore = true;
        Task.Run(() => {
            Thread.Sleep(1000);
            if (nextPage <= totalPages) {
                LoadData(nextPage);
            }
            isLoadingMore = false;
            IsRefreshing = false;
        });
    }

    void ExecutePullToRefreshCommand() {
        Task.Factory.StartNew(() => {
            Thread.Sleep(3000);
#pragma warning disable CS0612 // Type or member is obsolete
#pragma warning disable CS0618 // Type or member is obsolete
            Device.BeginInvokeOnMainThread(() => {
                nextPage = 1;
                totalPages = 1;
                Items.Clear();
                LoadData(nextPage);
                IsRefreshing = false;
            });
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning restore CS0612 // Type or member is obsolete
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

    ICommand pullToRefreshCommand = null;
    public ICommand PullToRefreshCommand {
        get => pullToRefreshCommand;
        set => SetProperty(ref this.pullToRefreshCommand, value);
    }

    async void LoadData(int page) {
        var response = await PurchaseOrderService.GetPurchaseOrderByStatus(5, page, 20);

        try {
            var pagedPurchaseOrders = JsonConvert.DeserializeObject<PagedPurchaseOrders>(response);
            totalPages = pagedPurchaseOrders.TotalPages;
            foreach (var item in pagedPurchaseOrders.Results) {
                if (!Items.Contains(item)) {
                    Items.Add(item);
                }
            }
            nextPage++;
        } catch (Exception) {
            await Shell.Current.DisplayAlert("Technical Difficulties", "Please ask your system administrator for assistance or try again later.", "OK");
        }
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query) {
        string id = HttpUtility.UrlDecode(query["id"] as string);
        var itemToRemove = Items.FirstOrDefault(item => item.Id == Convert.ToInt32(id));
        if (itemToRemove != null) {
            Items.Remove(itemToRemove);
        }
    }
}
