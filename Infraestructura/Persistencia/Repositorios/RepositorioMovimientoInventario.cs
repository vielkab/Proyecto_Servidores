using Aplicacion.Abstracciones.Persistencia;
using Dominio.Entidades.Inventario;

namespace Infraestructura.Persistencia.Repositorios;

public sealed class RepositorioMovimientoInventario : IRepositorioMovimientoInventario
{
    private readonly ContextoDb contextoDb;

    public RepositorioMovimientoInventario(ContextoDb contextoDb)
    {
        this.contextoDb = contextoDb;
    }

    public async Task AgregarAsync(MovimientoInventario movimientoInventario, CancellationToken cancellationToken = default)
    {
        await contextoDb.MovimientosInventario.AddAsync(movimientoInventario, cancellationToken);
    }

    public async Task AgregarRangoAsync(IEnumerable<MovimientoInventario> movimientosInventario, CancellationToken cancellationToken = default)
    {
        await contextoDb.MovimientosInventario.AddRangeAsync(movimientosInventario, cancellationToken);
    }
}
