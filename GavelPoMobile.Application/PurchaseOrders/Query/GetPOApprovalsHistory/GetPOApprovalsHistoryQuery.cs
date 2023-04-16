using ErrorOr;
using GavelPoMobile.Application.PurchaseOrders.Common;
using MediatR;

namespace GavelPoMobile.Application.PurchaseOrders.Query.GetPOApprovalsHistory;
public record GetPOApprovalsHistoryQuery(
    int? Page,
    int? PageSize
) : IRequest<ErrorOr<PurchaseOrderResponse>>;
