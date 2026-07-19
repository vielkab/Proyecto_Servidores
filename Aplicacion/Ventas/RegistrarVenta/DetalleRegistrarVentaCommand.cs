namespace Aplicacion.Ventas.RegistrarVenta;

public sealed record DetalleRegistrarVentaCommand(Guid ProductoId, int Cantidad, decimal PrecioUnitario);
