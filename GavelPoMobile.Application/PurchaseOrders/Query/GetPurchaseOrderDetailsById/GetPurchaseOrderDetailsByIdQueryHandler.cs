using ErrorOr;
using GavelPoMobile.Application.Common.Interfaces.Persistence;
using GavelPoMobile.Application.PurchaseOrders.Common;
using GavelPoMobile.Domain.Aggregates.Entities;
using GavelPoMobile.Domain.Common.Errors;
using MediatR;

namespace GavelPoMobile.Application.PurchaseOrders.Query.GetPurchaseOrderDetailsById;
public class GetPurchaseOrderDetailsByIdQueryHandler : IRequestHandler<GetPurchaseOrderDetailsByIdQuery, ErrorOr<PurchaseOrderDetailResponse>> {

    private readonly IPurchaseOrderRepository _purchaseOrderRepository;

    public GetPurchaseOrderDetailsByIdQueryHandler(IPurchaseOrderRepository purchaseOrderRepository) {
        _purchaseOrderRepository = purchaseOrderRepository;
    }

    public async Task<ErrorOr<PurchaseOrderDetailResponse>> Handle(GetPurchaseOrderDetailsByIdQuery request, CancellationToken cancellationToken) {
        await Task.CompletedTask;

        PurchaseOrderDetail purchaseOrderDetail = _purchaseOrderRepository.GetPurchaseOrderDetailsById(request.Id);

        if (purchaseOrderDetail == null) {
            return new[] { Errors.PurchaseOrder.NoPurchaseOrderDetailFound };
        }
        return new PurchaseOrderDetailResponse(purchaseOrderDetail.OID,
                                               purchaseOrderDetail.SourceNo,
                                               purchaseOrderDetail.GenJournalID,
                                               purchaseOrderDetail.Description,
                                               purchaseOrderDetail.Quantity,
                                               purchaseOrderDetail.UOM,
                                               purchaseOrderDetail.Cost,
                                               purchaseOrderDetail.CostCenter,
                                               purchaseOrderDetail.RequestedBy,
                                               purchaseOrderDetail.Total,
                                               purchaseOrderDetail.LineApprovalStatus,
                                               purchaseOrderDetail.Remarks);
    }
}
