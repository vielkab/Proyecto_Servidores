namespace Aplicacion.Comun.Resultados;

public sealed class Result<T> : Result
{
    private Result(T? valor, bool esExitoso, Error error)
        : base(esExitoso, error)
    {
        Valor = valor;
    }

    public T? Valor { get; }

    public static Result<T> Exito(T valor)
    {
        return new Result<T>(valor, true, Error.Ninguno);
    }

    public static new Result<T> Fallo(Error error)
    {
        return new Result<T>(default, false, error);
    }
}
