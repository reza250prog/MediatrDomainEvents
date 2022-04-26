namespace MediatrDomainEvents.Entities.DomainEvents
{
    public abstract class DomainEvent
    {
        protected DomainEvent()
        {
            DateOccurred = DateTime.Now;
        }

        public bool IsPublished { get; set; }
        public DateTimeOffset DateOccurred { get; protected set; } = DateTime.Now;
    }
}
