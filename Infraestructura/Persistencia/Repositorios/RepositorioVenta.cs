using Aplicacion.Abstracciones.Persistencia;
using Dominio.Entidades.Ventas;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Persistencia.Repositorios;

public sealed class RepositorioVenta : IRepositorioVenta
{
    private readonly ContextoDb contextoDb;

    public RepositorioVenta(ContextoDb contextoDb)
    {
        this.contextoDb = contextoDb;
    }

    public async Task AgregarAsync(Venta venta, CancellationToken cancellationToken = default)
    {
        await contextoDb.Ventas.AddAsync(venta, cancellationToken);
    }

    public Task<Venta?> ObtenerPorIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return contextoDb.Ventas.Include(venta => venta.Detalles).FirstOrDefaultAsync(venta => venta.Id == id, cancellationToken);
    }
}
