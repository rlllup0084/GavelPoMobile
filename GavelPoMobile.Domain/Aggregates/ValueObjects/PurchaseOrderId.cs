using GavelPoMobile.Domain.Common.Models;

namespace GavelPoMobile.Domain.Aggregates.ValueObjects;
public sealed class PurchaseOrderId : ValueObject {
    public int Value { get; }

    public PurchaseOrderId(int value) {
        Value = value;
    }

    public override IEnumerable<object> GetEqualityComponent() {
        yield return Value;
    }
}