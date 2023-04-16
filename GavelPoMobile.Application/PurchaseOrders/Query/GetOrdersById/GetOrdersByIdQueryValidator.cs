using FluentValidation;

namespace GavelPoMobile.Application.PurchaseOrders.Query.GetOrdersById;
public class GetOrdersByIdQueryValidator : AbstractValidator<GetOrdersByIdQuery> {
    public GetOrdersByIdQueryValidator() {
        // RuleFor(x => x.Id).NotEmpty();
    }
}
