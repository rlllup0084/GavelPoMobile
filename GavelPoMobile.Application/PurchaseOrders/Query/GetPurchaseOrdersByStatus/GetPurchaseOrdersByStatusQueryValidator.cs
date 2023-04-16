using FluentValidation;
using GavelPoMobile.Application.PurchaseOrders.Query.GetAllPurchaseOrders;

namespace GavelPoMobile.Application.PurchaseOrders.Query.GetPurchaseOrdersByStatus;
public class GetPurchaseOrdersByStatusQueryValidator 
    : AbstractValidator<GetPurchaseOrdersByStatusQuery> {
    public GetPurchaseOrdersByStatusQueryValidator() {
        RuleFor(x => x.status).NotEmpty();
        RuleFor(x => x.Page).NotEmpty();
        RuleFor(x => x.PageSize).NotEmpty();
    }
}
