namespace MediatrDomainEvents.Entities.DomainEvents
{
    public interface IHasDomainEvent
    {
        public List<DomainEvent> DomainEvents { get; set; }
    }

}
