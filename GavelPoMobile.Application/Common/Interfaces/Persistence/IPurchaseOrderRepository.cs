using GavelPoMobile.Application.Common.Models;
using GavelPoMobile.Domain.Aggregates;
using GavelPoMobile.Domain.Aggregates.Entities;

namespace GavelPoMobile.Application.Common.Interfaces.Persistence;
public interface IPurchaseOrderRepository {
    PurchaseOrder GetPurchaseOrderById(int? Id);
    PagedPurchaseOrders GetAllPurchaseOrders(int? page, int? pageSize);
    PagedPurchaseOrders GetPurchaseOrdersByStatus(int? status, int? page, int? pageSize);
    PurchaseOrderDetail GetPurchaseOrderDetailsById(int? purchaseOrderId);
    PagedPurchaseOrders GetPOApprovalsHistory(int? page, int? pageSize);
}
