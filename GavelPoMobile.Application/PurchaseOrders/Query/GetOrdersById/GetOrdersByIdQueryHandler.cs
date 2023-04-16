using ErrorOr;
using GavelPoMobile.Application.Common.Interfaces.Persistence;
using GavelPoMobile.Application.PurchaseOrders.Common;
using GavelPoMobile.Domain.Aggregates;
using GavelPoMobile.Domain.Common.Errors;
using MediatR;

namespace GavelPoMobile.Application.PurchaseOrders.Query.GetOrdersById;
public class GetOrdersByIdQueryHandler : IRequestHandler<GetOrdersByIdQuery, ErrorOr<PurchaseOrderByIdResponse>> {

    private readonly IPurchaseOrderRepository _purchaseOrderRepository;

    public GetOrdersByIdQueryHandler(IPurchaseOrderRepository purchaseOrderRepository) {
        _purchaseOrderRepository = purchaseOrderRepository;
    }

    public async Task<ErrorOr<PurchaseOrderByIdResponse>> Handle(GetOrdersByIdQuery request, CancellationToken cancellationToken) {
        await Task.CompletedTask;

        PurchaseOrder purchaseOrder = await _purchaseOrderRepository.GetPurchaseOrderById(request.Id);

        if (purchaseOrder == null) {
            return new[] { Errors.PurchaseOrder.PurchaseOrderNotFound };
        }
        return new PurchaseOrderByIdResponse(purchaseOrder.OID,
                                             purchaseOrder.ReferenceNo,
                                             purchaseOrder.Status,
                                             purchaseOrder.Remarks,
                                             purchaseOrder.Total,
                                             purchaseOrder.VendorOID,
                                             purchaseOrder.SourceNo,
                                             purchaseOrder.EntryDate,
                                             purchaseOrder.VendorName,
                                             purchaseOrder.PurchaseOrderDetails.ToList());
    }
}
