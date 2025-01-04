
using BuildingBlocks.Data;

namespace Basket.API.Basket.DeleteBasket
{
    public record DeleteBasketCommand(string UserName):ICommand<DeleteBasketResult>;
    public record DeleteBasketResult(bool IsSuccess);
    public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
    {
        public DeleteBasketCommandValidator()
        {
            RuleFor(command => command.UserName).NotEmpty().WithMessage("UserName is required");
        }
    }
    public class DeleteBasketCommandHandler(IBasketRepository repository) : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
    {
        public async Task<DeleteBasketResult> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
        {
            await repository.DeleteBasket(request.UserName);
            return new DeleteBasketResult(true);
        }
    }
}
