namespace GavelPoMobile.Contract.PurchaseOrder.PurchaseOrdersList;
public record PurchaseOrderResponse(
    int Page,
    int PageSize,
    int TotalPages,
    List<PurchaseOrderResult>? Results
    );
