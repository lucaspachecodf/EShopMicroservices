using MediatR;

namespace Eshop.Microservices.BuildingBlocks.CQRS
{
    public interface ICommand : ICommand<Unit>
    {

    }

    public interface ICommand<out TResponse> : IRequest<TResponse>
    {

    }
}
