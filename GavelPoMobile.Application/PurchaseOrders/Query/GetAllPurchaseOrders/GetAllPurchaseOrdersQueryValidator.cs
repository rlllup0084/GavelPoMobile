using FluentValidation;

namespace GavelPoMobile.Application.PurchaseOrders.Query.GetAllPurchaseOrders;
public class GetAllPurchaseOrdersQueryValidator : AbstractValidator<GetAllPurchaseOrdersQuery> {
    public GetAllPurchaseOrdersQueryValidator() {
        RuleFor(x => x.Page).NotEmpty();
        RuleFor(x => x.PageSize).NotEmpty();
    }
}
