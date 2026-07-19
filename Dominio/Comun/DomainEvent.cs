namespace Dominio.Comun;

public abstract record DomainEvent : IDomainEvent
{
    protected DomainEvent()
    {
        Id = Guid.NewGuid();
        OcurridoEn = DateTime.UtcNow;
    }

    public Guid Id { get; }

    public DateTime OcurridoEn { get; }
}
