using MediatrDomainEvents.Enums;

namespace MediatrDomainEvents.DTO
{
    public class CreateToDoItem
    {
        public string? Title { get; set; }

        public string? Note { get; set; }

        public PriorityLevel Priority { get; set; }

        public DateTime? Reminder { get; set; }

        public bool Done { get; set; }
    }
}
