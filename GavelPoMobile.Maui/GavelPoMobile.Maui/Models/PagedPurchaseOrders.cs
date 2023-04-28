namespace GavelPoMobile.Maui.Models;
public class PagedPurchaseOrders {
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public List<PurchaseOrderData> Results { get; set; } = new();
}
