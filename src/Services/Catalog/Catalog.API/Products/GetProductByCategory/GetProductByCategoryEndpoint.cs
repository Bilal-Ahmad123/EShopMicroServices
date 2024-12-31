using Catalog.API.Models;

namespace Catalog.API.Products.GetProductByCategory
{
    public class GetProductByCategoryEndpoint:ICarterModule
    {
        public record GetProductCategoryResponse(IEnumerable<Product> Products);
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/category/{category}", async (ISender sender, string category) =>
            {
                var result = await sender.Send(new GetProductByCategoryQuery(category));
                var response = result.Adapt<GetProductCategoryResponse>();
                return Results.Ok(response);

            });
        }


    }
}
