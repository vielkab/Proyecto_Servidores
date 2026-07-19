using Aplicacion.Abstracciones.Persistencia;
using Dominio.Entidades.Contabilidad;

namespace Infraestructura.Persistencia.Repositorios;

public sealed class RepositorioAsientoContable : IRepositorioAsientoContable
{
    private readonly ContextoDb contextoDb;

    public RepositorioAsientoContable(ContextoDb contextoDb)
    {
        this.contextoDb = contextoDb;
    }

    public async Task AgregarAsync(AsientoContable asientoContable, CancellationToken cancellationToken = default)
    {
        await contextoDb.AsientosContables.AddAsync(asientoContable, cancellationToken);
    }
}
