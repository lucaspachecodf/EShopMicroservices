using MediatR;

namespace Eshop.Microservices.BuildingBlocks.CQRS
{
    public interface IQuery<out TResponse> : IRequest<TResponse> where TResponse : notnull
    {

    }
}
