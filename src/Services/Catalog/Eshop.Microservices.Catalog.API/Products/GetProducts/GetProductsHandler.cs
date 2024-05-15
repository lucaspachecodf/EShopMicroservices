using Marten.Linq.QueryHandlers;

namespace Eshop.Microservices.Catalog.API.Products.GetProducts
{
    public record GetProductsQuery() : IQuery<GetProductsResult>;
    public record GetProductsResult(IEnumerable<Product> Products);

    internal class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, GetProductsResult>
    {
        public Task<GetProductsResult> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
