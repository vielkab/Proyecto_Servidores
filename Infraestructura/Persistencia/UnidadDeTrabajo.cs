using Aplicacion.Abstracciones.Persistencia;

namespace Infraestructura.Persistencia;

public sealed class UnidadDeTrabajo : IUnidadDeTrabajo
{
    private readonly ContextoDb contextoDb;

    public UnidadDeTrabajo(ContextoDb contextoDb)
    {
        this.contextoDb = contextoDb;
    }

    public Task<int> GuardarCambiosAsync(CancellationToken cancellationToken = default)
    {
        return contextoDb.SaveChangesAsync(cancellationToken);
    }
}
