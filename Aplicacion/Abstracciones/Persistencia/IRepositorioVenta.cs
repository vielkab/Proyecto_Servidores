using Dominio.Entidades.Ventas;

namespace Aplicacion.Abstracciones.Persistencia;

public interface IRepositorioVenta
{
    Task AgregarAsync(Venta venta, CancellationToken cancellationToken = default);

    Task<Venta?> ObtenerPorIdAsync(Guid id, CancellationToken cancellationToken = default);
}
