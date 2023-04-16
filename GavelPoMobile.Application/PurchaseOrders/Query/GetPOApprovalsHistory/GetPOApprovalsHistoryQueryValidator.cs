using FluentValidation;

namespace GavelPoMobile.Application.PurchaseOrders.Query.GetPOApprovalsHistory;
public class GetPOApprovalsHistoryQueryValidator : AbstractValidator<GetPOApprovalsHistoryQuery> {
    public GetPOApprovalsHistoryQueryValidator() {
        RuleFor(x => x.Page).NotEmpty();
        RuleFor(x => x.PageSize).NotEmpty();
    }
}
