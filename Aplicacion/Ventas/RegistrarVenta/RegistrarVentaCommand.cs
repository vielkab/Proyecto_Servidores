using Dominio.Entidades.Ventas;

namespace Aplicacion.Ventas.RegistrarVenta;

public sealed record RegistrarVentaCommand(
    Guid UsuarioId,
    MetodoPago MetodoPago,
    IReadOnlyCollection<DetalleRegistrarVentaCommand> Detalles,
    Guid CuentaVentasId,
    Guid? CuentaCajaBancoId,
    Guid? CuentaClientesPorCobrarId
);
