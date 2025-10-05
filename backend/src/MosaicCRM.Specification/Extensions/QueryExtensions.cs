using MosaicCRM.Specification.Abstractions;

namespace MosaicCRM.Specification.Extensions;

public static class QueryExtensions
{
    public static IQueryable<T> Specification<T>(this IQueryable<T> query, ISpecification<T> specification)
    {
        return query.Where(specification.ToExpression());
    }
}