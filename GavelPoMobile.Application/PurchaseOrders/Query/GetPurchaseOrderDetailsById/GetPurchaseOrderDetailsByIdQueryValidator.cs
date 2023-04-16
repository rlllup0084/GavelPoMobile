using FluentValidation;

namespace GavelPoMobile.Application.PurchaseOrders.Query.GetPurchaseOrderDetailsById;
public class GetPurchaseOrderDetailsByIdQueryValidator : AbstractValidator<GetPurchaseOrderDetailsByIdQuery> {
    public GetPurchaseOrderDetailsByIdQueryValidator() {
        RuleFor(x => x.Id).NotEmpty();
    }
}
