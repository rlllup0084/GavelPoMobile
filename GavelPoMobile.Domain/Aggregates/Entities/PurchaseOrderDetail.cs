namespace GavelPoMobile.Domain.Aggregates.Entities;
public sealed class PurchaseOrderDetail {
    public int OID { get; set; }
        public string? SourceNo { get; set; }
        public int? GenJournalID { get; set; }
        public string? Description { get; set; }
        public decimal? Quantity { get; set; }
        public string? UOM { get; set; }
        public decimal? Cost { get; set; }
        public string? CostCenter { get; set; }
        public string? RequestedBy { get; set; }
        public decimal? Total { get; set; }
        public int? LineApprovalStatus { get; set; }
        public string? Remarks { get; set; }
}