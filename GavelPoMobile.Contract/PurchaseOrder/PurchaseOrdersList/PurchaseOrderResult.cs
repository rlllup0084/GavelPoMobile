namespace GavelPoMobile.Contract.PurchaseOrder.PurchaseOrdersList;
public record PurchaseOrderResult(
    int Id,
    string? SourceNo,
    DateTime? EntryDate,
    string? Vendor,
    string? ReferenceNo,
    int? Status,
    string? Remarks,
    decimal? Total
    );
