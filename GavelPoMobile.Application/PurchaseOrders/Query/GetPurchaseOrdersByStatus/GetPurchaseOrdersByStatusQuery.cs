using ErrorOr;
using GavelPoMobile.Application.PurchaseOrders.Common;
using MediatR;

namespace GavelPoMobile.Application.PurchaseOrders.Query.GetPurchaseOrdersByStatus;
public record GetPurchaseOrdersByStatusQuery(
    int? status,
    int? Page,
    int? PageSize
    ) : IRequest<ErrorOr<PurchaseOrderResponse>>;
