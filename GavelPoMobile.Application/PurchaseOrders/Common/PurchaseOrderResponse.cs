using ErrorOr;
using GavelPoMobile.Domain.Aggregates;

namespace GavelPoMobile.Application.PurchaseOrders.Common;
public record PurchaseOrderResponse(
    int Page,
    int PageSize,
    int TotalPages,
    List<PurchaseOrder>? Results
    );
