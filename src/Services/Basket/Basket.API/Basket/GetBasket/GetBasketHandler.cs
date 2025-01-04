

using BuildingBlocks.Data;

namespace Basket.API.Basket.GetBasket
{
    public record GetBasketResult(ShoppingCart Cart);
    public record GetBasketQuery(string UserName):IQuery<GetBasketResult>;

    public class GetBasketQueryHandler(IBasketRepository repository) : IQueryHandler<GetBasketQuery, GetBasketResult>
    {
        public async Task<GetBasketResult> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            var basket = await repository.GetBasket(request.UserName);
            return new GetBasketResult(basket);
        }
    }
}
