using ErrorOr;
using GavelPoMobile.Application.Common.Interfaces.Persistence;
using GavelPoMobile.Application.PurchaseOrders.Common;
using GavelPoMobile.Domain.Aggregates.Entities;
using GavelPoMobile.Domain.Common.Errors;
using MediatR;

namespace GavelPoMobile.Application.PurchaseOrders.Commands.UpdatePOLineStatus;
public class UpdatePOLineStatusCommandHandler :
        IRequestHandler<UpdatePOLineStatusCommand, ErrorOr<PurchaseOrderDetailResponse>> {

    private readonly IPurchaseOrderRepository _purchaseOrderRepository;

    public UpdatePOLineStatusCommandHandler(IPurchaseOrderRepository purchaseOrderRepository) {
        _purchaseOrderRepository = purchaseOrderRepository;
    }

    public async Task<ErrorOr<PurchaseOrderDetailResponse>> Handle(UpdatePOLineStatusCommand command, CancellationToken cancellationToken) {
        await Task.CompletedTask;

        // Validate that the PurchaseOrderDetail Exist
        var poDetail = await _purchaseOrderRepository.GetPurchaseOrderDetailByLineId(command.Id);
        if (poDetail == null) {
            return new[] { Errors.PurchaseOrder.NoPurchaseOrderDetailFound };
        }

        // Validate that the PurchaseOrderDetail is not already in the same status and remarks is unchanged
        if (poDetail.LineApprovalStatus == command.LineApprovalStatus && poDetail.Remarks == command.Remarks) {
            return RetPurchaseOrderDetail(poDetail);
        }

        var result = await _purchaseOrderRepository.UpdatePurchaseOrderDetailStatus(command.Id, command.LineApprovalStatus, command.Remarks);

        poDetail.LineApprovalStatus = result.LineApprovalStatus;
        poDetail.Remarks = result.Remarks;

        return RetPurchaseOrderDetail(poDetail);
    }

    private static ErrorOr<PurchaseOrderDetailResponse> RetPurchaseOrderDetail(PurchaseOrderDetail poDetail) {
        return new PurchaseOrderDetailResponse(poDetail.OID,
                                               poDetail.SourceNo,
                                               poDetail.GenJournalID,
                                               poDetail.Description,
                                               poDetail.Quantity,
                                               poDetail.Uom,
                                               poDetail.Cost,
                                               poDetail.CostCenter,
                                               poDetail.RequestedBy,
                                               poDetail.Total,
                                               poDetail.LineApprovalStatus,
                                               poDetail.Remarks);
    }
}
