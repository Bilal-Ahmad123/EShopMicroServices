using BuildingBlocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Products.GetProducts
{
    public record GetProductResult(IEnumerable<Product> Products);
    public record GetProductQuery() : IQuery<GetProductResult>;
    public class GetProductsQueryHandler(IDocumentSession session) : IQueryHandler<GetProductQuery, GetProductResult>
    {
        public async Task<GetProductResult> Handle(GetProductQuery query, CancellationToken cancellationToken)
        {
            var products = await session.Query<Product>().ToListAsync(cancellationToken);
            return new GetProductResult(products);
        }
    }
}
