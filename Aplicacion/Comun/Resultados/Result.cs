namespace Aplicacion.Comun.Resultados;

public class Result
{
    protected Result(bool esExitoso, Error error)
    {
        EsExitoso = esExitoso;
        Error = error;
    }

    public bool EsExitoso { get; }

    public bool EsError => !EsExitoso;

    public Error Error { get; }

    public static Result Exito()
    {
        return new Result(true, Error.Ninguno);
    }

    public static Result Fallo(Error error)
    {
        return new Result(false, error);
    }
}
