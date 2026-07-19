using Dominio.Comun;

namespace Aplicacion.Abstracciones.Eventos;

public interface IDomainEventDispatcher
{
    Task DispatchAsync(IReadOnlyCollection<IDomainEvent> eventos, CancellationToken cancellationToken = default);
}
