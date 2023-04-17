using ErrorOr;
using GavelPoMobile.Application.PurchaseOrders.Common;
using MediatR;

namespace GavelPoMobile.Application.PurchaseOrders.Query.GetPurchaseOrdersByStatus;
public record GetPurchaseOrdersByStatusQuery(
    int? Status,
    int? Page,
    int? PageSize
    ) : IRequest<ErrorOr<PurchaseOrderResponse>>;
