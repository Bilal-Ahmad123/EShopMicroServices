
namespace Catalog.API.Products.UpdateProduct
{
    public record UpdateProductRequest(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price);
    public record UpdateProductResponse(Guid Id);
    public class UpdateProductEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/products/{id}", async (UpdateProductRequest request, ISender sender,Guid id) =>
            {
                var result = await sender.Send(new UpdateProductCommand(id, request.Name, request.Description, request.Price, request.ImageFile,request.Category));
                var response = result.Adapt<UpdateProductResponse>();
                return Results.Ok(response);
            });
        }
    }
}
