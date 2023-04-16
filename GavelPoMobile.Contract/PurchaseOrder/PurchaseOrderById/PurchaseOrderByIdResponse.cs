using GavelPoMobile.Contract.PurchaseOrderDetail;

namespace GavelPoMobile.Contract.PurchaseOrder.PurchaseOrderById;
public record PurchaseOrderByIdResponse(
    int Id,
    string ReferenceNo,
    int? Status,
    string Remarks,
    decimal? Total,
    Guid VendorId,
    string SourceNo,
    DateTime? EntryDate,
    string VendorName,
    List<PurchaseOrderDetailResult> PurchaseOrderDetails
    );
