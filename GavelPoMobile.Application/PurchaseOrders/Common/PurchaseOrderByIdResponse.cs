using GavelPoMobile.Domain.Aggregates.Entities;

namespace GavelPoMobile.Application.PurchaseOrders.Common;
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
    List<PurchaseOrderDetail> PurchaseOrderDetails
    );
