namespace Aplicacion.Compras.RegistrarCompra;

public sealed record DetalleRegistrarCompraCommand(Guid ProductoId, int Cantidad, decimal PrecioCompra);
