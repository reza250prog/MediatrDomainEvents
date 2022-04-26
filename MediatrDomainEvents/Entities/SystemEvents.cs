namespace MediatrDomainEvents.Entities
{
    public class SystemEvents : AuditableEntity
    {
        public int Id { get; set; }

        public string? Event { get; set; }
    }
}
