using BuildingBlocks.CQRS;

namespace Catalog.API.Products.DeleteProduct
{
    public record DeleteProductCommand(Guid Id):ICommand<DeleteProductResult>;
    public record DeleteProductResult(Guid Id);
    public class DeleteProductHandler(IDocumentSession session) : ICommandHandler<DeleteProductCommand, DeleteProductResult>
    {
        public Task<DeleteProductResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
