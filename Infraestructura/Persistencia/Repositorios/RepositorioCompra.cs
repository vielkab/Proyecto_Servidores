using Aplicacion.Abstracciones.Persistencia;
using Dominio.Entidades.Compras;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Persistencia.Repositorios;

public sealed class RepositorioCompra : IRepositorioCompra
{
    private readonly ContextoDb contextoDb;

    public RepositorioCompra(ContextoDb contextoDb)
    {
        this.contextoDb = contextoDb;
    }

    public async Task AgregarAsync(Compra compra, CancellationToken cancellationToken = default)
    {
        await contextoDb.Compras.AddAsync(compra, cancellationToken);
    }

    public Task<Compra?> ObtenerPorIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return contextoDb.Compras.Include(compra => compra.Detalles).FirstOrDefaultAsync(compra => compra.Id == id, cancellationToken);
    }
}
