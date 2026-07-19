using Dominio.Entidades.Compras;

namespace Aplicacion.Abstracciones.Persistencia;

public interface IRepositorioCompra
{
    Task AgregarAsync(Compra compra, CancellationToken cancellationToken = default);

    Task<Compra?> ObtenerPorIdAsync(Guid id, CancellationToken cancellationToken = default);
}
