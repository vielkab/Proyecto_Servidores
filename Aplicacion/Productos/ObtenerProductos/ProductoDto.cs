namespace Aplicacion.Productos.ObtenerProductos;

public sealed record ProductoDto(
    Guid Id,
    string CodigoBarras,
    string Nombre,
    decimal PrecioCompra,
    decimal PrecioVenta,
    decimal Ganancia,
    string Descripcion,
    int Stock,
    int StockMinimo,
    bool Activo,
    DateTime FechaCreacion,
    Guid IdCategoria
);
