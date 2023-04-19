namespace GavelPoMobile.SandBox3.Request; 
public record UpdatePurchaseOrderStatusRequest {
    public int? Oid { get; init; }
    public int? Status { get; init; }
    public string? Remarks { get; init; }
}
