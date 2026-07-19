namespace Aplicacion.Comun.Resultados;

public sealed record Error(string Codigo, string Mensaje)
{
    public static readonly Error Ninguno = new(string.Empty, string.Empty);
}
