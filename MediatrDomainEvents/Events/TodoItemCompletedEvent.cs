using MediatrDomainEvents.Entities;
using MediatrDomainEvents.Entities.DomainEvents;

namespace MediatrDomainEvents.Events
{
    public class TodoItemCompletedEvent : DomainEvent
    {
        public TodoItemCompletedEvent(TodoItem item)
        {
            Item = item;
        }

        public TodoItem Item { get; }
    }
}
