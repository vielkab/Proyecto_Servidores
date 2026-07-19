using Dominio.Entidades.Contabilidad;

namespace Aplicacion.Abstracciones.Persistencia;

public interface IRepositorioAsientoContable
{
    Task AgregarAsync(AsientoContable asientoContable, CancellationToken cancellationToken = default);
}
