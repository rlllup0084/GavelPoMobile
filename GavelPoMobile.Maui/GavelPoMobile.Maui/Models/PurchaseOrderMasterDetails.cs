using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GavelPoMobile.Maui.Models;

public class PurchaseOrderMasterDetails
{
    public PurchaseOrderMasterDetails() {
    }

    public int Id { get; set; }
    public string ReferenceNo { get; set; }
    public int Status { get; set; }
    public string Remarks { get; set; }
    public decimal Total { get; set; }
    public string SourceNo { get; set; }
    public DateTime EntryDate { get; set; }
    public string VendorName { get; set; }
    public List<PurchaseOrderDetail> PurchaseOrderDetails { get; set; } = new();
}

public class PurchaseOrderDetail : INotifyPropertyChanged {
    private string remarks;

    public int Id { get; set; }
    public string SourceNo { get; set; }
    public int? GenJournalId { get; set; }
    public string Description { get; set; }
    public decimal? Quantity { get; set; }
    public string Uom { get; set; }
    public decimal? Cost { get; set; }
    public string CostCenter { get; set; }
    public string RequestedBy { get; set; }
    public decimal? Total { get; set; }
    public int LineApprovalStatus { get; set; }
    public string Remarks {
        get => remarks;
        set {
            string oldRemarks = remarks;
            if (remarks != value) {
                remarks = value;
                if (oldRemarks != null && oldRemarks != "Has no remarks...") {
                    OnPropertyChanged(nameof(Remarks));
                    //UpdateDatabase();
                    DetailChanged?.Invoke(this, new PurchaseOrderDetailChangedEventArgs(nameof(Remarks), oldRemarks, remarks, this.Id, this.LineApprovalStatus));
                }
            }
        }
    }
    public bool HasRemarks { get; set; } = false;

    public event AsyncEventHandler<PurchaseOrderDetailChangedEventArgs> DetailChanged;

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public class PurchaseOrderDetailChangedEventArgs : EventArgs {
    public string PropertyName { get; }
    public int DetailId { get; set; }
    public int Status { get; set; }
    public object OldValue { get; }
    public object NewValue { get; }

    public PurchaseOrderDetailChangedEventArgs(string propertyName, object oldValue, object newValue, int detailId, int status) {
        PropertyName = propertyName;
        OldValue = oldValue;
        NewValue = newValue;
        DetailId = detailId;
        Status = status;
    }
}

public delegate Task AsyncEventHandler<TEventArgs>(object sender, TEventArgs e) where TEventArgs : EventArgs;