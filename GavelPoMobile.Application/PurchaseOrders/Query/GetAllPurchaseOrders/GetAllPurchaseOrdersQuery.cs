using ErrorOr;
using GavelPoMobile.Application.PurchaseOrders.Common;
using MediatR;

namespace GavelPoMobile.Application.PurchaseOrders.Query.GetAllPurchaseOrders;
public record GetAllPurchaseOrdersQuery(
    int? Page,
    int? PageSize
    ) : IRequest<ErrorOr<PurchaseOrderResponse>>;
