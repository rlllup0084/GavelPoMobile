using ErrorOr;
using GavelPoMobile.Application.Common.Interfaces.Persistence;
using GavelPoMobile.Application.Common.Models;
using GavelPoMobile.Application.PurchaseOrders.Common;
using GavelPoMobile.Domain.Common.Errors;
using MediatR;

namespace GavelPoMobile.Application.PurchaseOrders.Query.GetPurchaseOrdersByStatus;
public class GetPurchaseOrdersByStatusQueryHandler : IRequestHandler<GetPurchaseOrdersByStatusQuery, ErrorOr<PurchaseOrderResponse>> {

    private readonly IPurchaseOrderRepository _purchaseOrderRepository;

    public GetPurchaseOrdersByStatusQueryHandler(IPurchaseOrderRepository purchaseOrderRepository) {
        _purchaseOrderRepository = purchaseOrderRepository;
    }

    public async Task<ErrorOr<PurchaseOrderResponse>> Handle(GetPurchaseOrdersByStatusQuery request, CancellationToken cancellationToken) {
        await Task.CompletedTask;

        PagedPurchaseOrders pagedPurchaseOrders = await _purchaseOrderRepository.GetPurchaseOrdersByStatus(request.Status, request.Page, request.PageSize);

        if (pagedPurchaseOrders == null) {
            return new[] { Errors.PurchaseOrder.NoPurchaseOrdersFound };
        }

        return new PurchaseOrderResponse(pagedPurchaseOrders.Page,
                                          pagedPurchaseOrders.PageSize,
                                          pagedPurchaseOrders.TotalPages,
                                          pagedPurchaseOrders.PurchaseOrders.ToList());
    }
}
