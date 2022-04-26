using MediatrDomainEvents.Entities;
using MediatrDomainEvents.Entities.DomainEvents;

namespace MediatrDomainEvents.Events
{
    public class TodoItemAddedEvent : DomainEvent
    {
        public TodoItemAddedEvent(TodoItem item)
        {
            Item = item;
        }

        public TodoItem Item { get; }
    }
}