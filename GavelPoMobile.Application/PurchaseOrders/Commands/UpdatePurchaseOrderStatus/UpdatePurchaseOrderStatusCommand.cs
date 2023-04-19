using ErrorOr;
using GavelPoMobile.Application.PurchaseOrders.Common;
using MediatR;

namespace GavelPoMobile.Application.PurchaseOrders.Commands.UpdatePurchaseOrderStatus;
public record UpdatePurchaseOrderStatusCommand(
    int Id,
    int Status,
    string Remarks
    ) : IRequest<ErrorOr<PurchaseOrderByIdResponse>>;
