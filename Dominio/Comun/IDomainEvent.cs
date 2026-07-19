namespace Dominio.Comun;

public interface IDomainEvent
{
    Guid Id { get; }

    DateTime OcurridoEn { get; }
}
