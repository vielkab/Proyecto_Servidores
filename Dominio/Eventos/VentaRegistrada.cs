using Dominio.Comun;

namespace Dominio.Eventos;

public sealed record VentaRegistrada(Guid VentaId, Guid UsuarioId, decimal Total) : DomainEvent;
