using Aplicacion.Comun.CQRS;
using Aplicacion.Comun.Resultados;
using Aplicacion.Compras.RegistrarCompra;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/compras")]
public sealed class ComprasController : ControllerBase
{
    [HttpPost]
    public async Task<IResult> Registrar(
        RegistrarCompraCommand command,
        ICommandHandler<RegistrarCompraCommand, Guid> handler,
        CancellationToken cancellationToken
    )
    {
        var result = await handler.Handle(command, cancellationToken);

        return result.EsExitoso
            ? Results.Created($"/api/compras/{result.Valor}", new { Id = result.Valor })
            : CrearRespuestaError(result);
    }

    private static IResult CrearRespuestaError(Result result)
    {
        return Results.BadRequest(new { result.Error.Codigo, result.Error.Mensaje });
    }
}
