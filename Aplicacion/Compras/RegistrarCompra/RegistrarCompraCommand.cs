namespace Aplicacion.Compras.RegistrarCompra;

public sealed record RegistrarCompraCommand(
    Guid ProveedorId,
    Guid PedidoId,
    IReadOnlyCollection<DetalleRegistrarCompraCommand> Detalles,
    Guid CuentaInventarioId,
    Guid CuentaProveedoresPorPagarId
);
