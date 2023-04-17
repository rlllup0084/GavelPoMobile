namespace GavelPoMobile.Contract.PurchaseOrderDetail;
public record PurchaseOrderDetailResult(
    int Id,
    string SourceNo,
    int? GenJournalId,
    string Description,
    decimal? Quantity,
    string UOM,
    decimal? Cost,
    string CostCenter,
    string RequestedBy,
    decimal? Total,
    int? LineApprovalStatus,
    string Remarks
    );
