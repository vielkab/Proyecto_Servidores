using Dominio.Entidades.Categoria;

namespace Aplicacion.Abstracciones.Persistencia;

public interface IRepositorioCategoria
{
    Task AgregarAsync(Categoria categoria, CancellationToken cancellationToken = default);

    Task<Categoria?> ObtenerPorIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<Categoria>> ObtenerTodasAsync(CancellationToken cancellationToken = default);
}
