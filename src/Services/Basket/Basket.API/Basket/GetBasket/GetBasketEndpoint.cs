using Mapster;
namespace Basket.API.Basket.GetBasket
{
    public record GetBasketReponse(ShoppingCart Cart);

    public class GetBasketEndpoint: ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/basket/{userName}", async (ISender sender, string userName) =>
            {
                var result = await sender.Send(new GetBasketQuery(userName));
                var response = result.Adapt<GetBasketReponse>();
                return Results.Ok(response);
            });
        }

    }
}
