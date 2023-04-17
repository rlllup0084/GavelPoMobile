using GavelPoMobile.Application.Common.Models;
using GavelPoMobile.Domain.Aggregates;
using GavelPoMobile.Domain.Aggregates.Entities;

namespace GavelPoMobile.Application.Common.Interfaces.Persistence;
public interface IPurchaseOrderRepository {
    Task<PurchaseOrder> GetPurchaseOrderById(int? Id, CancellationToken cancellationToken = default);
    Task<PagedPurchaseOrders> GetAllPurchaseOrders(int? page, int? pageSize, CancellationToken cancellationToken = default);
    Task<PagedPurchaseOrders> GetPurchaseOrdersByStatus(int? status, int? page, int? pageSize, CancellationToken cancellationToken = default);
    Task<List<PurchaseOrderDetail>> GetPurchaseOrderDetailsById(int? purchaseOrderId, CancellationToken cancellationToken = default);
}
