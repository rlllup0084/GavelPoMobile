namespace GavelPoMobile.Maui.Models;

public class PurchaseOrderData {
    public int Id { get; set; }
    public string SourceNo { get; set; }
    public DateTime EntryDate { get; set; }
    public string Vendor { get; set; }
    public string ReferenceNo { get; set;}
    public int Status { get; set; }
    public string Remarks { get; set; }
    public double Total { get; set; }
}
