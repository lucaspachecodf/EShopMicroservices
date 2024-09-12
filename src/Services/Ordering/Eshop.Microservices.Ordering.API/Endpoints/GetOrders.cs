using Carter;
using Eshop.Microservices.BuildingBlocks.Pagination;
using Eshop.Microservices.Ordering.Application.Dtos;
using Eshop.Microservices.Ordering.Application.Orders.Queries.GetOrders;
using Mapster;
using MediatR;

namespace Eshop.Microservices.Ordering.API.Endpoints
{
    public record GetOrdersResponse(PaginatedResult<OrderDto> Orders);

    public class GetOrders : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/orders", async ([AsParameters] PaginationRequest request, ISender sender) =>
            {
                var result = await sender.Send(new GetOrdersQuery(request));

                var response = result.Adapt<GetOrdersResponse>();

                return Results.Ok(response);
            })
            .WithName("GetOrders")
            .Produces<GetOrdersResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Orders")
            .WithDescription("Get Orders");
        }
    }
}
