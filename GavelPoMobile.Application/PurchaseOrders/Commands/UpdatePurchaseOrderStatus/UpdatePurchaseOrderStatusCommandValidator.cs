using FluentValidation;

namespace GavelPoMobile.Application.PurchaseOrders.Commands.UpdatePurchaseOrderStatus;
public class UpdatePurchaseOrderStatusCommandValidator : AbstractValidator<UpdatePurchaseOrderStatusCommand> {
    public UpdatePurchaseOrderStatusCommandValidator() {
        RuleFor(x => x.Id).NotEmpty();
        //RuleFor(x => x.Status).NotEmpty();
    }
}
