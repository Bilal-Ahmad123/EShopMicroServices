using BuildingBlocks.CQRS;

namespace Catalog.API.Products.GetProducts
{
    public record GetProductResult(IEnumerable<Catalog.API.Models.Products> products);
    public record GetProductQuery():IQuery<GetProductResult>;
    public class GetProductsQueryHandler(IDocumentSession session,ILogger<GetProductsQueryHandler> logger):IQueryHandler<GetProductQuery, GetProductResult>
    {
        public async Task<GetProductResult> Handle(GetProductQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductQueryHandler.handle called the query");
            var products = await session.Query<Catalog.API.Models.Products>().ToListAsync(cancellationToken);
            return new GetProductResult(products);
        }
    }
}
