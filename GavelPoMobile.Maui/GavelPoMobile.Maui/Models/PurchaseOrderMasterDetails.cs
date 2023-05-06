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
    public int? LineApprovalStatus { get; set; }
    public string Remarks {
        get => remarks;
        set {
            string oldRemarks = remarks;
            if (remarks != value) {
                remarks = value;
                if (oldRemarks != null && oldRemarks != "Has no remarks...") {
                    OnPropertyChanged(nameof(Remarks));
                    //UpdateDatabase();
                    RemarksChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }
    public bool HasRemarks { get; set; } = false;

    public event EventHandler RemarksChanged;

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    //private void UpdateDatabase() {
    //    Console.WriteLine("Remarks Changed");
    //    // Implement your database update logic here
    //    // For example:
    //    // using (var dbContext = new MyDbContext())
    //    // {
    //    //     var entity = dbContext.PurchaseOrderDetails.FirstOrDefault(x => x.Id == this.Id);
    //    //     entity.Remarks = this.Remarks;
    //    //     dbContext.SaveChanges();
    //    // }
    //}
}
