using Aplicacion.Abstracciones.Eventos;
using Dominio.Comun;
using Microsoft.Extensions.Logging;

namespace Infraestructura.Eventos;

public sealed class DomainEventDispatcher : IDomainEventDispatcher
{
    private readonly ILogger<DomainEventDispatcher> logger;

    public DomainEventDispatcher(ILogger<DomainEventDispatcher> logger)
    {
        this.logger = logger;
    }

    public Task DispatchAsync(IReadOnlyCollection<IDomainEvent> eventos, CancellationToken cancellationToken = default)
    {
        foreach (var evento in eventos)
        {
            logger.LogInformation("Domain event publicado: {Evento} ({EventoId})", evento.GetType().Name, evento.Id);
        }

        return Task.CompletedTask;
    }
}
