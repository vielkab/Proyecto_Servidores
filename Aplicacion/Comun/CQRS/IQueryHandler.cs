using Aplicacion.Comun.Resultados;

namespace Aplicacion.Comun.CQRS;

public interface IQueryHandler<in TQuery, TResult>
{
    Task<Result<TResult>> Handle(TQuery query, CancellationToken cancellationToken = default);
}
