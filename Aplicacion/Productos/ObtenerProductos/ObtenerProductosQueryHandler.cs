using Aplicacion.Abstracciones.Persistencia;
using Aplicacion.Comun.CQRS;
using Aplicacion.Comun.Resultados;

namespace Aplicacion.Productos.ObtenerProductos;

public sealed class ObtenerProductosQueryHandler : IQueryHandler<ObtenerProductosQuery, IReadOnlyCollection<ProductoDto>>
{
    private readonly IRepositorioProducto repositorioProducto;

    public ObtenerProductosQueryHandler(IRepositorioProducto repositorioProducto)
    {
        this.repositorioProducto = repositorioProducto;
    }

    public async Task<Result<IReadOnlyCollection<ProductoDto>>> Handle(
        ObtenerProductosQuery query,
        CancellationToken cancellationToken = default
    )
    {
        var productos = await repositorioProducto.ObtenerTodosAsync(cancellationToken);
        var resultado = productos
            .Select(producto => new ProductoDto(
                producto.Id,
                producto.Codigo_Barras,
                producto.Nombre,
                producto.PrecioCompra,
                producto.PrecioVenta,
                producto.Ganancia,
                producto.Descripcion,
                producto.Stock,
                producto.StockMinimo,
                producto.Activo,
                producto.FechaCreacion,
                producto.IdCategoria
            ))
            .ToArray();

        return Result<IReadOnlyCollection<ProductoDto>>.Exito(resultado);
    }
}
