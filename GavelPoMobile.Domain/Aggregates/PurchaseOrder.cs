using GavelPoMobile.Domain.Aggregates.Entities;

namespace GavelPoMobile.Domain.Aggregates;
public sealed class PurchaseOrder
{
    public int OID { get; set; }
    public string? SourceNo { get; set; }
    public DateTime? EntryDate { get; set; }
    public string? Vendor { get; set; }
    public string? ReferenceNo { get; set; }
    public int? Status { get; set; }
    public string? Remarks { get; set; }
    public decimal? Total { get; set; }
    public List<PurchaseOrderDetail>? PurchaseOrderDetails { get; set; }
}
