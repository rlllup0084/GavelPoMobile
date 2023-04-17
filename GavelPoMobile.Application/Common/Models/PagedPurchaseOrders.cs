using GavelPoMobile.Domain.Aggregates;

namespace GavelPoMobile.Application.Common.Models;
public sealed class PagedPurchaseOrders {
    private readonly List<PurchaseOrder> _purchaseOrders = new();
    public PagedPurchaseOrders(int page, int pageSize, int totalPages, List<PurchaseOrder> purchaseOrders) {
        Page = page;
        PageSize = pageSize;
        TotalPages = totalPages;
        _purchaseOrders = purchaseOrders;
    }
 
    public int Page { get; }
    public int PageSize { get; }
    public int TotalPages { get; }
    public IReadOnlyList<PurchaseOrder> PurchaseOrders => _purchaseOrders.AsReadOnly();
}
