﻿namespace Eshop.Microservices.Ordering.Domain.Events
{
    public record OrderUpdatedEvent(Order order) : IDomainEvent;
}
