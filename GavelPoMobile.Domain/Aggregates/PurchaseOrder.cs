using GavelPoMobile.Domain.Aggregates.Entities;

namespace GavelPoMobile.Domain.Aggregates;
public sealed class PurchaseOrder {
    private readonly List<PurchaseOrderDetail> _purchaseOrderDetails = new();

    public PurchaseOrder(int oID, string referenceNo, int? status, string remarks, decimal? total, Guid vendorOID,
                         string sourceNo, DateTime? entryDate, string vendorName,
                         List<PurchaseOrderDetail> purchaseOrderDetails) {
        OID = oID;
        ReferenceNo = referenceNo;
        Status = status;
        Remarks = remarks;
        Total = total;
        VendorOID = vendorOID;
        SourceNo = sourceNo;
        EntryDate = entryDate;
        VendorName = vendorName;
        _purchaseOrderDetails = purchaseOrderDetails;
    }

    public int OID { get; }
    public string ReferenceNo { get; }
    public int? Status { get; }
    public string Remarks { get; }
    public decimal? Total { get; }
    public Guid VendorOID { get; }
    public string SourceNo { get; }
    public DateTime? EntryDate { get; }
    public string VendorName { get; }

    public IReadOnlyList<PurchaseOrderDetail> PurchaseOrderDetails => _purchaseOrderDetails.AsReadOnly();
}
