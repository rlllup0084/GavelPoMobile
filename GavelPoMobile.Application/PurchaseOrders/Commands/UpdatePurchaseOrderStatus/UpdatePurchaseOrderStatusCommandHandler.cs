using ErrorOr;
using GavelPoMobile.Application.Common.Interfaces.Persistence;
using GavelPoMobile.Application.PurchaseOrders.Common;
using GavelPoMobile.Domain.Aggregates;
using GavelPoMobile.Domain.Common.Errors;
using MediatR;

namespace GavelPoMobile.Application.PurchaseOrders.Commands.UpdatePurchaseOrderStatus {
    public class UpdatePurchaseOrderStatusCommandHandler :
        IRequestHandler<UpdatePurchaseOrderStatusCommand, ErrorOr<PurchaseOrderByIdResponse>> {

        private readonly IPurchaseOrderRepository _purchaseOrderRepository;

        public UpdatePurchaseOrderStatusCommandHandler(IPurchaseOrderRepository purchaseOrderRepository) {
            _purchaseOrderRepository = purchaseOrderRepository;
        }

        public async Task<ErrorOr<PurchaseOrderByIdResponse>> Handle(UpdatePurchaseOrderStatusCommand command, CancellationToken cancellationToken) {
            await Task.CompletedTask;

            // Validate that the PurchaseOrder Exist
            var purchaseOrder = await _purchaseOrderRepository.GetPurchaseOrderById(command.Id);
            if (purchaseOrder is null) {
                return new[] { Errors.PurchaseOrder.PurchaseOrderNotFound };
            }

            // Validate that the PurchaseOrder is not already in the same status and remarks is unchanged
            if (purchaseOrder.Status == command.Status && purchaseOrder.Remarks == command.Remarks) {
                return RetPurchaseOrder(purchaseOrder);
            }

            var result = await _purchaseOrderRepository.UpdatePurchaseOrderStatus(command.Id, command.Status, command.Remarks, cancellationToken);

            purchaseOrder.Status = result.Status;
            purchaseOrder.Remarks = result.Remarks;

            return RetPurchaseOrder(purchaseOrder);

        }

        private static ErrorOr<PurchaseOrderByIdResponse> RetPurchaseOrder(PurchaseOrder purchaseOrder) {
            return new PurchaseOrderByIdResponse(purchaseOrder.OID,
                                         purchaseOrder.ReferenceNo,
                                         purchaseOrder.Status,
                                         purchaseOrder.Remarks,
                                         purchaseOrder.Total,
                                         purchaseOrder.SourceNo,
                                         purchaseOrder.EntryDate,
                                         purchaseOrder.Vendor,
                                         purchaseOrder.PurchaseOrderDetails?.ToList());
        }
    }
}
