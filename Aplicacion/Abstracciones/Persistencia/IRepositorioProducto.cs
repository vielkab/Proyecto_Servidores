using Dominio.Entidades.Inventario;

namespace Aplicacion.Abstracciones.Persistencia;

public interface IRepositorioProducto
{
    Task AgregarAsync(Producto producto, CancellationToken cancellationToken = default);

    Task<Producto?> ObtenerPorIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<Producto>> ObtenerTodosAsync(CancellationToken cancellationToken = default);

    Task<bool> ExisteCodigoBarrasAsync(string codigoBarras, CancellationToken cancellationToken = default);
}
