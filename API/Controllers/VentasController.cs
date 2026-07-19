using Aplicacion.Comun.CQRS;
using Aplicacion.Comun.Resultados;
using Aplicacion.Ventas.RegistrarVenta;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/ventas")]
public sealed class VentasController : ControllerBase
{
    [HttpPost]
    public async Task<IResult> Registrar(
        RegistrarVentaCommand command,
        ICommandHandler<RegistrarVentaCommand, Guid> handler,
        CancellationToken cancellationToken
    )
    {
        var result = await handler.Handle(command, cancellationToken);

        return result.EsExitoso
            ? Results.Created($"/api/ventas/{result.Valor}", new { Id = result.Valor })
            : CrearRespuestaError(result);
    }

    private static IResult CrearRespuestaError(Result result)
    {
        return Results.BadRequest(new { result.Error.Codigo, result.Error.Mensaje });
    }
}
