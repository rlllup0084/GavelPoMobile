using GavelPoMobile.Maui.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace GavelPoMobile.Maui.ViewModels;
public class HistoryViewModel : BaseViewModel {
    int nextPage = 1;
    int totalPages = 1;
    public HistoryViewModel() {
        Title = "All Purchases";
        Items = new ObservableCollection<PurchaseOrderData>();
        LoadMoreCommand = new Command(ExecuteLoadMoreCommand);
        PullToRefreshCommand = new Command(ExecutePullToRefreshCommand);
        OpenPurchaseOrder = new Command<PurchaseOrderData>(ExecuteOpenPurchaseOrder);
    }

    async void ExecuteOpenPurchaseOrder(PurchaseOrderData purchaseOrder) {
        switch (purchaseOrder.Status) {
            case 0:
                await Navigation.NavigateToAsync<PurchaseOrderViewModel>(purchaseOrder.Id.ToString());
                break;
            case 1:
                await Navigation.NavigateToAsync<OtherPurchaseOrderViewModel>(purchaseOrder.Id.ToString());
                break;
            case 2:
                await Navigation.NavigateToAsync<OtherPurchaseOrderViewModel>(purchaseOrder.Id.ToString());
                break;
            case 3:
                await Navigation.NavigateToAsync<OtherPurchaseOrderViewModel>(purchaseOrder.Id.ToString());
                break;
            case 4:
                await Navigation.NavigateToAsync<OtherPurchaseOrderViewModel>(purchaseOrder.Id.ToString());
                break;
            case 5:
                await Navigation.NavigateToAsync<PendingPurchaseOrderViewModel>(purchaseOrder.Id.ToString());
                break;
            default:
                break;
        }        
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
        try {
            var response = await PurchaseOrderService.GetAllPurchaseOrders(page, 20);

            var pagedPurchaseOrders = JsonConvert.DeserializeObject<PagedPurchaseOrders>(response);
            totalPages = pagedPurchaseOrders.TotalPages;
            foreach (var item in pagedPurchaseOrders.Results) {
                if (!Items.Contains(item)) {
                    Items.Add(item);
                }
            }
            nextPage++;
        } catch (Exception ex) {
            if (ex.Message == "Session Expired") {
                AlertService.ShowAlert("Session Expired", "Your session has expired. Please log in again.", "OK");
                await Navigation.NavigateToAsync<LoginViewModel>(true);
            } else {
                AlertService.ShowAlert("Technical Difficulties", "Please contact your system administrator for assistance or try again later.", "OK");
            }
        }
    }
}
