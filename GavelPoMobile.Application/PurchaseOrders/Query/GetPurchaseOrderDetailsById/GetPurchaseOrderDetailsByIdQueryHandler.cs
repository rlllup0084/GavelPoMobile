using ErrorOr;
using GavelPoMobile.Application.Common.Interfaces.Persistence;
using GavelPoMobile.Application.PurchaseOrders.Common;
using GavelPoMobile.Domain.Common.Errors;
using MediatR;

namespace GavelPoMobile.Application.PurchaseOrders.Query.GetPurchaseOrderDetailsById;
public class GetPurchaseOrderDetailsByIdQueryHandler : IRequestHandler<GetPurchaseOrderDetailsByIdQuery, ErrorOr<List<PurchaseOrderDetailResponse>>> {

    private readonly IPurchaseOrderRepository _purchaseOrderRepository;

    public GetPurchaseOrderDetailsByIdQueryHandler(IPurchaseOrderRepository purchaseOrderRepository) {
        _purchaseOrderRepository = purchaseOrderRepository;
    }

    public async Task<ErrorOr<List<PurchaseOrderDetailResponse>>> Handle(GetPurchaseOrderDetailsByIdQuery request, CancellationToken cancellationToken) {
        await Task.CompletedTask;

        var results = await _purchaseOrderRepository.GetPurchaseOrderDetailsById(request.Id);

        if (results == null) {
            return new[] { Errors.PurchaseOrder.NoPurchaseOrderDetailFound };
        }

        return results.Select(o => new PurchaseOrderDetailResponse(o.OID,
                            o.SourceNo,
                            o.GenJournalID,
                            o.Description,
                            o.Quantity,
                            o.UOM,
                            o.Cost,
                            o.CostCenter,
                            o.RequestedBy,
                            o.Total,
                            o.LineApprovalStatus,
                            o.Remarks)).ToList();
    }
}
