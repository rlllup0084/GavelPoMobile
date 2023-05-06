using System.Web;

namespace GavelPoMobile.Maui.ViewModels;

public class PurchaseOrderDetailInfoViewModel : BaseViewModel, IQueryAttributable {
    private int id;
    private string description;
    private decimal quantity;
    private string uom;
    private decimal cost;
    private string costCenter;
    private string requestedBy;
    private decimal total;
    private int lineApprovalStatus;
    private string remarks;

    public int Id {
        get => id;
        set => SetProperty(ref id, value);
    }
    public string Description {
        get => description;
        set => SetProperty(ref description, value);
    }
    public decimal Quantity {
        get => quantity;
        set => SetProperty(ref quantity, value);
    }
    public string Uom {
        get => uom;
        set => SetProperty(ref uom, value);
    }
    public decimal Cost {
        get => cost;
        set => SetProperty(ref cost, value);
    }
    public string CostCenter {
        get => costCenter;
        set => SetProperty(ref costCenter, value);
    }
    public string RequestedBy {
        get => requestedBy;
        set => SetProperty(ref requestedBy, value);
    }
    public decimal Total {
        get => total;
        set => SetProperty(ref total, value);
    }
    public int LineApprovalStatus {
        get => lineApprovalStatus;
        set => SetProperty(ref lineApprovalStatus, value);
    }
    public string Remarks {
        get => remarks;
        set => SetProperty(ref remarks, value);
    }
    public PurchaseOrderDetailInfoViewModel() {
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query) {
        string id = HttpUtility.UrlDecode(query["id"] as string);
        Console.WriteLine(id);
        //await LoadPurchaseOrderId(id);
    }

    public async Task LoadPurchaseOrderDetailId(string purchaseOrderDetailId) {
        await Task.CompletedTask;
        //var response = await PurchaseOrderService.GetPurchaseOrderById(Convert.ToInt32(purchaseOrderId));

        //try {
        //    var purchaseOrder = JsonConvert.DeserializeObject<PurchaseOrderMasterDetails>(response);
        //    Title = purchaseOrder.SourceNo;
        //    switch (purchaseOrder.Status) {
        //        case 0:
        //            StatusIcon = "current.png";
        //            break;
        //        case 1:
        //            StatusIcon = "approve.png";
        //            break;
        //        case 2:
        //            StatusIcon = "approve.png";
        //            break;
        //        case 3:
        //            StatusIcon = "approve.png";
        //            break;
        //        case 4:
        //            StatusIcon = "disapprove.png";
        //            break;
        //        case 5:
        //            StatusIcon = "pending.png";
        //            break;
        //        default:
        //            break;
        //    }
        //    Id = purchaseOrder.Id;
        //    ReferenceNo = purchaseOrder.ReferenceNo;
        //    Status = purchaseOrder.Status;
        //    Remarks = purchaseOrder.Remarks;
        //    Total = purchaseOrder.Total;
        //    SourceNo = purchaseOrder.SourceNo;
        //    EntryDate = purchaseOrder.EntryDate;
        //    VendorName = purchaseOrder.VendorName;
        //    PurchaseOrderDetails.AddRange(purchaseOrder.PurchaseOrderDetails);
        //} catch (Exception) {
        //    await Shell.Current.DisplayAlert("Technical Difficulties", "Please ask your system administrator for assistance or try again later.", "OK");
        //} finally {
        //    isLoading = false;
        //    BtnApproveText = "Approve";
        //    BtnDisapproveText = "Disapprove";
        //}
    }
}
