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

public class PurchaseOrderDetail {
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
    public string Remarks { get; set; }
}
