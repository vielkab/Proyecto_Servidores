using Aplicacion.Abstracciones.Persistencia;
using Aplicacion.Comun.CQRS;
using Aplicacion.Comun.Resultados;
using Dominio.Entidades.Categoria;

namespace Aplicacion.Categorias.CrearCategoria;

public sealed class CrearCategoriaCommandHandler : ICommandHandler<CrearCategoriaCommand, Guid>
{
    private readonly IRepositorioCategoria repositorioCategoria;
    private readonly IUnidadDeTrabajo unidadDeTrabajo;

    public CrearCategoriaCommandHandler(IRepositorioCategoria repositorioCategoria, IUnidadDeTrabajo unidadDeTrabajo)
    {
        this.repositorioCategoria = repositorioCategoria;
        this.unidadDeTrabajo = unidadDeTrabajo;
    }

    public async Task<Result<Guid>> Handle(CrearCategoriaCommand command, CancellationToken cancellationToken = default)
    {
        try
        {
            var categoria = Categoria.Crear(command.Nombre, command.Descripcion);

            await repositorioCategoria.AgregarAsync(categoria, cancellationToken);
            await unidadDeTrabajo.GuardarCambiosAsync(cancellationToken);

            return Result<Guid>.Exito(categoria.Id);
        }
        catch (ArgumentException ex)
        {
            return Result<Guid>.Fallo(new Error("Categoria.DatosInvalidos", ex.Message));
        }
    }
}
