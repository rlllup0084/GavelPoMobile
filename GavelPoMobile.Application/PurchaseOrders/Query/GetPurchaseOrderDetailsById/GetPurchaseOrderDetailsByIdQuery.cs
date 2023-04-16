using ErrorOr;
using GavelPoMobile.Application.PurchaseOrders.Common;
using MediatR;

namespace GavelPoMobile.Application.PurchaseOrders.Query.GetPurchaseOrderDetailsById;
public record GetPurchaseOrderDetailsByIdQuery(
    int Id
    ) : IRequest<ErrorOr<PurchaseOrderDetailResponse>>;
