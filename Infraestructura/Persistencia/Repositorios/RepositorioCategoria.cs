using Aplicacion.Abstracciones.Persistencia;
using Dominio.Entidades.Categoria;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Persistencia.Repositorios;

public sealed class RepositorioCategoria : IRepositorioCategoria
{
    private readonly ContextoDb contextoDb;

    public RepositorioCategoria(ContextoDb contextoDb)
    {
        this.contextoDb = contextoDb;
    }

    public async Task AgregarAsync(Categoria categoria, CancellationToken cancellationToken = default)
    {
        await contextoDb.Categorias.AddAsync(categoria, cancellationToken);
    }

    public Task<Categoria?> ObtenerPorIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return contextoDb.Categorias.FirstOrDefaultAsync(categoria => categoria.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyCollection<Categoria>> ObtenerTodasAsync(CancellationToken cancellationToken = default)
    {
        return await contextoDb.Categorias.AsNoTracking().OrderBy(categoria => categoria.Nombre).ToArrayAsync(cancellationToken);
    }
}
