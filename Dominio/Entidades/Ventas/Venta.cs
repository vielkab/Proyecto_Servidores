using Dominio.Comun;
using Dominio.Eventos;

namespace Dominio.Entidades.Ventas;

public class Venta
{
    private readonly List<IDomainEvent> eventosDominio = new();

    public Guid Id { get; private set; }

    public DateTime Fecha { get; private set; }

    public decimal Total { get; private set; }

    public MetodoPago MetodoPago { get; private set; }

    public Guid UsuarioId { get; private set; }

    public ICollection<DetalleVenta> Detalles { get; private set; } = new List<DetalleVenta>();

    public IReadOnlyCollection<IDomainEvent> EventosDominio => eventosDominio.AsReadOnly();

    private Venta(Guid usuarioId, MetodoPago metodoPago, DateTime fecha)
    {
        if (usuarioId == Guid.Empty)
        {
            throw new ArgumentException("El usuario es obligatorio.", nameof(usuarioId));
        }

        if (!Enum.IsDefined(typeof(MetodoPago), metodoPago))
        {
            throw new ArgumentException("El metodo de pago no es valido.", nameof(metodoPago));
        }


        Id = Guid.NewGuid();
        Fecha = fecha == default ? DateTime.UtcNow : fecha;
        Total = 0;
        MetodoPago = metodoPago;
        UsuarioId = usuarioId;
        Detalles = new List<DetalleVenta>();
    }

    public static Venta Crear(Guid usuarioId, MetodoPago metodoPago, DateTime? fecha = null)
    {
        return new Venta(usuarioId, metodoPago, fecha ?? DateTime.UtcNow);
    }

    public void AgregarDetalle(Guid productoId, int cantidad, decimal precioUnitario)
    {
        var detalle = DetalleVenta.Crear(Id, productoId, cantidad, precioUnitario);
        Detalles.Add(detalle);
        Total += detalle.Subtotal;
    }

    public void RegistrarEventoVentaRegistrada()
    {
        if (Detalles.Count == 0)
        {
            throw new InvalidOperationException("La venta debe tener al menos un detalle.");
        }

        eventosDominio.Add(new VentaRegistrada(Id, UsuarioId, Total));
    }

    public void LimpiarEventosDominio()
    {
        eventosDominio.Clear();
    }
}
