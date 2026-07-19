using Aplicacion.Categorias.CrearCategoria;
using Aplicacion.Categorias.ObtenerCategorias;
using Aplicacion.Comun.CQRS;
using Aplicacion.Comun.Resultados;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/categorias")]
public sealed class CategoriasController : ControllerBase
{
    [HttpPost]
    public async Task<IResult> Crear(
        CrearCategoriaCommand command,
        ICommandHandler<CrearCategoriaCommand, Guid> handler,
        CancellationToken cancellationToken
    )
    {
        var result = await handler.Handle(command, cancellationToken);

        return result.EsExitoso
            ? Results.Created($"/api/categorias/{result.Valor}", new { Id = result.Valor })
            : CrearRespuestaError(result);
    }

    [HttpGet]
    public async Task<IResult> ObtenerTodas(
        IQueryHandler<ObtenerCategoriasQuery, IReadOnlyCollection<CategoriaDto>> handler,
        CancellationToken cancellationToken
    )
    {
        var result = await handler.Handle(new ObtenerCategoriasQuery(), cancellationToken);

        return result.EsExitoso ? Results.Ok(result.Valor) : CrearRespuestaError(result);
    }

    private static IResult CrearRespuestaError(Result result)
    {
        return Results.BadRequest(new { result.Error.Codigo, result.Error.Mensaje });
    }
}
