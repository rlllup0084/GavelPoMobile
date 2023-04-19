using FluentValidation;

namespace GavelPoMobile.Application.PurchaseOrders.Commands.UpdatePOLineStatus;
public class UpdatePOLineStatusCommandValidator : AbstractValidator<UpdatePOLineStatusCommand> {
    public UpdatePOLineStatusCommandValidator() {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.LineApprovalStatus).NotEmpty();
    }
}
