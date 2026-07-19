namespace Aplicacion.Productos.CrearProducto;

public sealed record CrearProductoCommand(
    string CodigoBarras,
    string Nombre,
    decimal PrecioCompra,
    decimal PrecioVenta,
    Guid IdCategoria,
    string? Descripcion,
    int Stock,
    int StockMinimo
);
