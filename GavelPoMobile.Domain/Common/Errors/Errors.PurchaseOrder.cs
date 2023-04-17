using ErrorOr;

namespace GavelPoMobile.Domain.Common.Errors;
public static partial class Errors {
    public static class PurchaseOrder {
        public static Error PurchaseOrderNotFound => Error.NotFound(code: "Purchase Order Not Found", description: "Purchase Order not found in the system.");
        public static Error NoPurchaseOrdersFound => Error.NotFound(code: "No Purchase Orders Found", description: "No purchase Orders found in the system.");
        public static Error NoPurchaseOrderDetailFound => Error.NotFound(code: "Purchase Order Detail Not Found", description: "No purchase Orders detail with this ID found in the system.");
    }
}
