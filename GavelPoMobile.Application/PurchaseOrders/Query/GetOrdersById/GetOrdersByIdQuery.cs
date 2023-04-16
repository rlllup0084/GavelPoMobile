using ErrorOr;
using GavelPoMobile.Application.PurchaseOrders.Common;
using MediatR;

namespace GavelPoMobile.Application.PurchaseOrders.Query.GetOrdersById;
public record GetOrdersByIdQuery(
    int Id
    ) : IRequest<ErrorOr<PurchaseOrderByIdResponse>>;
