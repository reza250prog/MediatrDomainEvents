using MediatR;
using MediatrDomainEvents.Data;
using MediatrDomainEvents.Entities;
using MediatrDomainEvents.Entities.DomainEvents;
using MediatrDomainEvents.Events;

namespace MediatrDomainEvents.EventHandlers
{
    public class TodoItemAddedEventHandler : INotificationHandler<DomainEventNotification<TodoItemAddedEvent>>
    {
        private readonly ILogger<TodoItemAddedEventHandler> _logger;
        private readonly ApplicationDbContext db;

        public TodoItemAddedEventHandler(ILogger<TodoItemAddedEventHandler> logger,
             ApplicationDbContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public Task Handle(DomainEventNotification<TodoItemAddedEvent> notification, CancellationToken cancellationToken)
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