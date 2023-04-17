using GavelPoMobile.Domain.Common.Models;

namespace GavelPoMobile.Domain.Aggregates.ValueObjects;

public sealed class PurchaseOrderDetailId : ValueObject {
    public int Value { get; }
    public PurchaseOrderDetailId(int value) {
        Value = value;
    }
    public override IEnumerable<object> GetEqualityComponent() {
        yield return Value;
    }
}