using Dominio.Entidades.Inventario;

namespace Aplicacion.Abstracciones.Persistencia;

public interface IRepositorioMovimientoInventario
{
    Task AgregarAsync(MovimientoInventario movimientoInventario, CancellationToken cancellationToken = default);

    Task AgregarRangoAsync(IEnumerable<MovimientoInventario> movimientosInventario, CancellationToken cancellationToken = default);
}
