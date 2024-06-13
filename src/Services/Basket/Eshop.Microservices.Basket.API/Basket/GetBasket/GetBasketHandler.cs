

namespace Eshop.Microservices.Basket.API.Basket.GetBasket
{
    public record GetBasketQuery(string UserName) : IQuery<GetBasketResult>;
    public record GetBasketResult(ShoppingCart Cart);

    public class GetBasketHandler
    {
        public class GetBasketQueryHandler() : IQueryHandler<GetBasketQuery, GetBasketResult>
        {
            public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
            {
                return new GetBasketResult(new ShoppingCart("Teste"));
            }
        }
    }
}
