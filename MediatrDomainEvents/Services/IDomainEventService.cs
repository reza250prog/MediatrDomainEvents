using MediatrDomainEvents.Entities.DomainEvents;

namespace MediatrDomainEvents.Services
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}