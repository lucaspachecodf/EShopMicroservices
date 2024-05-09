using Eshop.Microservices.BuildingBlocks.CQRS;
using Eshop.Microservices.Catalog.API.Models;
using MediatR;

namespace Eshop.Microservices.Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);


    internal class CreateProductHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price
            };

            return new CreateProductResult(Guid.NewGuid());
        }
    }
}
