using MediatR;
using MediatrDomainEvents.Data;
using MediatrDomainEvents.Entities;
using MediatrDomainEvents.Entities.DomainEvents;
using MediatrDomainEvents.Events;

namespace MediatrDomainEvents.EventHandlers
{
    public class TodoItemCompletedEventHandler : INotificationHandler<DomainEventNotification<TodoItemCompletedEvent>>
    {
        private readonly ILogger<TodoItemCompletedEventHandler> _logger;
        private readonly ApplicationDbContext db;

        public TodoItemCompletedEventHandler(ILogger<TodoItemCompletedEventHandler> logger, ApplicationDbContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public Task Handle(DomainEventNotification<TodoItemCompletedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            db.SystemEvents.AddAsync(new SystemEvents
            {
                Event = domainEvent.GetType().Name + " With Id : " + domainEvent.Item.Id
            },
                 cancellationToken)
                     .GetAwaiter();

            db.SaveChangesAsync(cancellationToken).GetAwaiter();
            return Task.CompletedTask;
        }
    }
}