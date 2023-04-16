using ErrorOr;
using GavelPoMobile.Application.Common.Interfaces.Persistence;
using GavelPoMobile.Application.Common.Models;
using GavelPoMobile.Application.PurchaseOrders.Common;
using GavelPoMobile.Domain.Common.Errors;
using MediatR;

namespace GavelPoMobile.Application.PurchaseOrders.Query.GetAllPurchaseOrders;
public class GetAllPurchaseOrdersQueryHandler : IRequestHandler<GetAllPurchaseOrdersQuery, ErrorOr<PurchaseOrderResponse>> {

    private readonly IPurchaseOrderRepository _purchaseOrderRepository;

    public GetAllPurchaseOrdersQueryHandler(IPurchaseOrderRepository purchaseOrderRepository) {
        _purchaseOrderRepository = purchaseOrderRepository;
    }

    public async Task<ErrorOr<PurchaseOrderResponse>> Handle(GetAllPurchaseOrdersQuery request, CancellationToken cancellationToken) {
        await Task.CompletedTask;

        PagedPurchaseOrders pagedPurchaseOrders = await _purchaseOrderRepository.GetAllPurchaseOrders(request.Page, request.PageSize);

        if (pagedPurchaseOrders == null) {
            return new[] { Errors.PurchaseOrder.NoPurchaseOrdersFound };
        }

        return new PurchaseOrderResponse(pagedPurchaseOrders.Page,
                                         pagedPurchaseOrders.PageSize,
                                         pagedPurchaseOrders.TotalPages,
                                         pagedPurchaseOrders.PurchaseOrders.ToList());
    }
}
