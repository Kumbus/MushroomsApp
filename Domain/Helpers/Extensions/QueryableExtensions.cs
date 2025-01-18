using Newtonsoft.Json;
using System.Linq.Expressions;

namespace Domain.Helpers.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> ApplyFilters<T>(this IQueryable<T> query, string filterJson)
        {
            if (string.IsNullOrEmpty(filterJson)) return query;

            var filters = JsonConvert.DeserializeObject<Dictionary<string, string>>(filterJson);
            foreach (var filter in filters)
            {
                var property = filter.Key;
                var value = filter.Value;

                var parameter = Expression.Parameter(typeof(T), "x");
                var propertyExpression = property.Split('.').Aggregate((Expression)parameter, Expression.Property);
                var constantExpression = Expression.Constant(Convert.ChangeType(value, propertyExpression.Type));
                var equalExpression = Expression.Equal(propertyExpression, constantExpression);

                var lambda = Expression.Lambda<Func<T, bool>>(equalExpression, parameter);
                query = query.Where(lambda);
            }

            return query;
        }

        public static IQueryable<T> ApplySorting<T>(this IQueryable<T> query, string sortBy, bool sortDescending)
        {
            if (string.IsNullOrEmpty(sortBy)) return query;

            var parameter = Expression.Parameter(typeof(T), "x");
            var propertyExpression = sortBy.Split('.').Aggregate((Expression)parameter, Expression.Property);
            var lambda = Expression.Lambda(propertyExpression, parameter);

            var methodName = sortDescending ? "OrderByDescending" : "OrderBy";
            var resultExpression = Expression.Call(typeof(Queryable), methodName,
                new Type[] { typeof(T), propertyExpression.Type },
                query.Expression, Expression.Quote(lambda));

            return query.Provider.CreateQuery<T>(resultExpression);
        }
    }

}
