using ErrorOr;
using GavelPoMobile.Application.PurchaseOrders.Common;
using MediatR;

namespace GavelPoMobile.Application.PurchaseOrders.Commands.UpdatePOLineStatus;
public record UpdatePOLineStatusCommand(
    int Id,
    int? LineApprovalStatus,
    string? Remarks
    ) : IRequest<ErrorOr<PurchaseOrderDetailResponse>>;
