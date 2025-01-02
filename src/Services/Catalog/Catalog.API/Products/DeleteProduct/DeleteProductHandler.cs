using BuildingBlocks.CQRS;
using Catalog.API.Models;
using Catalog.API.Products.UpdateProduct;

namespace Catalog.API.Products.DeleteProduct
{
    public record DeleteProductCommand(Guid Id):ICommand<DeleteProductResult>;
    public record DeleteProductResult(bool IsSuccess);

    public class DeleteProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty().WithMessage("ProductId is required");
        }
    }
    public class DeleteProductHandler(IDocumentSession session) : ICommandHandler<DeleteProductCommand, DeleteProductResult>
    {
        public async Task<DeleteProductResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            session.Delete<Product>(request.Id);
            await session.SaveChangesAsync(cancellationToken);
            return new DeleteProductResult(true);
        }
    }
}
