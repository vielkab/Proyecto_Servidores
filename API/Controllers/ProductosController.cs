using Aplicacion.Comun.CQRS;
using Aplicacion.Comun.Resultados;
using Aplicacion.Productos.CrearProducto;
using Aplicacion.Productos.ObtenerProductos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/productos")]
public sealed class ProductosController : ControllerBase
{
    [HttpPost]
    public async Task<IResult> Crear(
        CrearProductoCommand command,
        ICommandHandler<CrearProductoCommand, Guid> handler,
        CancellationToken cancellationToken
    )
    {
        var result = await handler.Handle(command, cancellationToken);

        return result.EsExitoso
            ? Results.Created($"/api/productos/{result.Valor}", new { Id = result.Valor })
            : CrearRespuestaError(result);
    }

    [HttpGet]
    public async Task<IResult> ObtenerTodos(
        IQueryHandler<ObtenerProductosQuery, IReadOnlyCollection<ProductoDto>> handler,
        CancellationToken cancellationToken
    )
    {
        var result = await handler.Handle(new ObtenerProductosQuery(), cancellationToken);

        return result.EsExitoso ? Results.Ok(result.Valor) : CrearRespuestaError(result);
    }

    private static IResult CrearRespuestaError(Result result)
    {
        return Results.BadRequest(new { result.Error.Codigo, result.Error.Mensaje });
    }
}
