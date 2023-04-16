namespace GavelPoMobile.Domain.Aggregates.Entities;
public sealed class PurchaseOrderDetail {
    public PurchaseOrderDetail(int oID, string sourceNo, int? genJournalID, string description, decimal? quantity, string uOM,
                               decimal? cost, string costCenter, string requestedBy, decimal? total,
                               int? lineApprovalStatus, string remarks) {
        OID = oID;
        SourceNo = sourceNo;
        GenJournalID = genJournalID;
        Description = description;
        Quantity = quantity;
        UOM = uOM;
        Cost = cost;
        CostCenter = costCenter;
        RequestedBy = requestedBy;
        Total = total;
        LineApprovalStatus = lineApprovalStatus;
        Remarks = remarks;
    }

    public int OID { get; }
    public string SourceNo { get; }
    public int? GenJournalID { get; }
    public string Description { get; }
    public decimal? Quantity { get; }
    public string UOM { get; }
    public decimal? Cost { get; }
    public string CostCenter { get; }
    public string RequestedBy { get; }
    public decimal? Total { get; }
    public int? LineApprovalStatus { get; }
    public string Remarks { get; }
}