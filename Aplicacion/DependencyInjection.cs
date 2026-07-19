using Aplicacion.Categorias.CrearCategoria;
using Aplicacion.Categorias.ObtenerCategorias;
using Aplicacion.Comun.CQRS;
using Aplicacion.Compras.RegistrarCompra;
using Aplicacion.Productos.CrearProducto;
using Aplicacion.Productos.ObtenerProductos;
using Aplicacion.Ventas.RegistrarVenta;
using Microsoft.Extensions.DependencyInjection;

namespace Aplicacion;

public static class DependencyInjection
{
    public static IServiceCollection AgregarAplicacion(this IServiceCollection services)
    {
        services.AddScoped<ICommandHandler<CrearCategoriaCommand, Guid>, CrearCategoriaCommandHandler>();
        services.AddScoped<IQueryHandler<ObtenerCategoriasQuery, IReadOnlyCollection<CategoriaDto>>, ObtenerCategoriasQueryHandler>();
        services.AddScoped<ICommandHandler<CrearProductoCommand, Guid>, CrearProductoCommandHandler>();
        services.AddScoped<IQueryHandler<ObtenerProductosQuery, IReadOnlyCollection<ProductoDto>>, ObtenerProductosQueryHandler>();
        services.AddScoped<ICommandHandler<RegistrarVentaCommand, Guid>, RegistrarVentaCommandHandler>();
        services.AddScoped<ICommandHandler<RegistrarCompraCommand, Guid>, RegistrarCompraCommandHandler>();

        return services;
    }
}
