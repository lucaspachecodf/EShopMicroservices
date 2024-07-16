namespace Eshop.Microservices.Ordering.Domain.Events
{
    public record OrderCreatedEvent(Order order) : IDomainEvent;
}
