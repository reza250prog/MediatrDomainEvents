using MediatrDomainEvents.DTO;
using MediatrDomainEvents.Entities.DomainEvents;
using MediatrDomainEvents.Enums;
using MediatrDomainEvents.Events;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediatrDomainEvents.Entities
{
    public class TodoItem : AuditableEntity, IHasDomainEvent
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Note { get; set; }

        public PriorityLevel Priority { get; set; }

        public DateTime? Reminder { get; set; }

        public bool Done { get; set; }

        public TodoItem()
        {
        }

        public TodoItem(CreateToDoItem model)
        {
            Title = model.Title;
            Note = model.Note;
            Priority = model.Priority;
            Reminder = model.Reminder;
            Done = model.Done;
            DomainEvents.Add(new TodoItemAddedEvent(this));
        }

        public void MarkAsComplete()
        {
            if (!Done)
            {
                Done = true;
                DomainEvents.Add(new TodoItemCompletedEvent(this));
            }
        }

        [NotMapped]
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
