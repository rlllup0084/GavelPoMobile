using DevExpress.Maui.Core.Internal;
using GavelPoMobile.Maui.Models;
using Microsoft.Maui;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Web;
using System.Windows.Input;

namespace GavelPoMobile.Maui.ViewModels;
public class PurchaseOrderDetailsViewModel : BaseViewModel, IQueryAttributable {

    private string id;
    private string statusIcon;
    private string sourceNo;

    public string Id {
        get => id;
        set => SetProperty(ref id, value);
    }

    public string StatusIcon {
        get => statusIcon;
        set => SetProperty(ref statusIcon, value);
    }
    public string SourceNo {
        get => sourceNo;
        set => SetProperty(ref sourceNo, value);
    }

    public ObservableCollection<PurchaseOrderDetail> Items { 
        get => items; 
        set => SetProperty(ref items, value); }

    public PurchaseOrderDetailsViewModel() {
        Items = new ObservableCollection<PurchaseOrderDetail>();
        PullToRefreshCommand = new Command(ExecutePullToRefreshCommand);
        OpenPurchaseOrderDetail = new Command<PurchaseOrderDetail>(ExecuteOpenPurchaseOrderDetail);
    }

    void ExecutePullToRefreshCommand() {
        Task.Factory.StartNew(() => {
            Thread.Sleep(3000);
#pragma warning disable CS0612 // Type or member is obsolete
#pragma warning disable CS0618 // Type or member is obsolete
            Device.BeginInvokeOnMainThread(async () => {
                if (!string.IsNullOrEmpty(this.id)) {
                    Items.Clear();
                    await LoadPurchaseOrderDetails(this.id);
                }
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

    ICommand pullToRefreshCommand = null;
    private ObservableCollection<PurchaseOrderDetail> items;

    public ICommand PullToRefreshCommand {
        get => pullToRefreshCommand;
        set => SetProperty(ref this.pullToRefreshCommand, value);
    }

    public Command<PurchaseOrderDetail> OpenPurchaseOrderDetail { get; }

    async void ExecuteOpenPurchaseOrderDetail(PurchaseOrderDetail purchaseOrderDetail) {
        //Console.WriteLine(purchaseOrderDetail.Id);
        await Navigation.NavigateToAsync<PurchaseOrderDetailInfoViewModel>(purchaseOrderDetail.Id.ToString());
    }

    public async void ApplyQueryAttributes(IDictionary<string, object> query) {
        string id = HttpUtility.UrlDecode(query["id"] as string);
        await LoadPurchaseOrderDetails(id);
    }

    private async Task LoadPurchaseOrderDetails(string id) {
        this.id = id;
        var response = await PurchaseOrderService.GetPurchaseOrderById(Convert.ToInt32(id));

        try {
            var purchaseOrder = JsonConvert.DeserializeObject<PurchaseOrderMasterDetails>(response);
            Title = purchaseOrder.SourceNo;
            switch (purchaseOrder.Status) {
                case 0:
                    StatusIcon = "current.png";
                    break;
                case 1:
                    StatusIcon = "approve.png";
                    break;
                case 2:
                    StatusIcon = "approve.png";
                    break;
                case 3:
                    StatusIcon = "approve.png";
                    break;
                case 4:
                    StatusIcon = "disapprove.png";
                    break;
                case 5:
                    StatusIcon = "pending.png";
                    break;
                default:
                    break;
            }
            //foreach (var item in purchaseOrder.PurchaseOrderDetails) {
            //    Items.Add(item);
            //}
            List<PurchaseOrderDetail> purchaseOrderDetails = purchaseOrder.PurchaseOrderDetails.Select(x => new PurchaseOrderDetail {
                Id = x.Id,
                SourceNo = x.SourceNo,
                GenJournalId = x.GenJournalId,
                Description = x.Description,
                Quantity = x.Quantity,
                Uom = x.Uom,
                Cost = x.Cost,
                CostCenter = x.CostCenter,
                RequestedBy = x.RequestedBy,
                Total = x.Total,
                LineApprovalStatus = x.LineApprovalStatus,
                Remarks = !string.IsNullOrEmpty(x.Remarks) ? x.Remarks : "Has no remarks...",
                HasRemarks = !string.IsNullOrEmpty(x.Remarks)
            }).ToList();

            foreach (var item in purchaseOrderDetails) {
                Items.Add(item);
            }
        } catch (Exception) {
            await Shell.Current.DisplayAlert("Technical Difficulties", "Please ask your system administrator for assistance or try again later.", "OK");
        }
    }
}
