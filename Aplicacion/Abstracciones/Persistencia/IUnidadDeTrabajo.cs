namespace Aplicacion.Abstracciones.Persistencia;

public interface IUnidadDeTrabajo
{
    Task<int> GuardarCambiosAsync(CancellationToken cancellationToken = default);
}
