using Eshop.Microservices.BuildingBlocks.Exceptions;

namespace Eshop.Microservices.Catalog.API.Exceptions
{
    public class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException(Guid Id) : base("Product", Id)
        {

        }
    }
}
