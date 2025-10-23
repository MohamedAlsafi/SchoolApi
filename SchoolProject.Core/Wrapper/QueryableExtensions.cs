using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Wrapper
{
    public static class QueryableExtensions
    {
        public static async Task<PaginatedResult<T>> ToPaginatedListAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize) where T : class
        {
            if (source is null) throw new ArgumentNullException(nameof(source));

            pageNumber = Math.Max(1, pageNumber);
            pageSize = Math.Max(1, pageSize);

            source = source.AsNoTracking();
            int count = await source.CountAsync();

            if (count == 0)
                return PaginatedResult<T>.Success(new List<T>(), 0, pageNumber, pageSize);

            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return PaginatedResult<T>.Success(items, count, pageNumber, pageSize);
        }


        public static IQueryable<T> ApplySearch<T>(this IQueryable<T> query, string? searchTerm, params Expression<Func<T, string>>[] searchableProperties)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) || searchableProperties == null || searchableProperties.Length == 0)
                return query;

            var parameter = Expression.Parameter(typeof(T), "x");
            Expression? combined = null;

            foreach (var prop in searchableProperties)
            {
                var replacedBody = ReplaceParameter(prop.Body, prop.Parameters[0], parameter);

                var notNull = Expression.NotEqual(replacedBody, Expression.Constant(null, typeof(string)));

                var containsMethod = typeof(string).GetMethod(nameof(string.Contains), new[] { typeof(string) })!;
                var containsCall = Expression.Call(replacedBody, containsMethod, Expression.Constant(searchTerm, typeof(string)));

                var andExpr = Expression.AndAlso(notNull, containsCall);
                combined = combined == null ? andExpr : Expression.OrElse(combined, andExpr);
            }

            var lambda = Expression.Lambda<Func<T, bool>>(combined!, parameter);
            return query.Where(lambda);
        }

        private static Expression ReplaceParameter(Expression expression, ParameterExpression from, ParameterExpression to)
        {
            return new ParameterReplacer(from, to).Visit(expression)!;
        }

        private class ParameterReplacer : ExpressionVisitor
        {
            private readonly ParameterExpression _from;
            private readonly ParameterExpression _to;
            public ParameterReplacer(ParameterExpression from, ParameterExpression to) { _from = from; _to = to; }
            protected override Expression VisitParameter(ParameterExpression node) => node == _from ? _to : base.VisitParameter(node);
        }


        public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> query, params Expression<Func<T, bool>>?[] filters)
        {
            if (filters is null || filters.Length == 0)
                return query;

            foreach (var filter in filters)
            {
                if (filter != null)
                    query = query.Where(filter);
            }

            return query;
        }


        public static IQueryable<T> ApplyOrder<T>(this IQueryable<T> query,string? sortBy,string? sortDirection = "asc")
        {
            if (string.IsNullOrWhiteSpace(sortBy))
                return query;

            var dir = (sortDirection ?? "asc").Trim().ToLowerInvariant();
            if (dir != "asc" && dir != "desc") dir = "asc";

            var entityType = typeof(T);
            var parameter = Expression.Parameter(entityType, "x");

            Expression propertyAccess = parameter;
            Type currentType = entityType;

            foreach (var propName in sortBy.Split('.'))
            {
                var prop = currentType.GetProperty(propName,
                    BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (prop == null)
                    return query; 

                propertyAccess = Expression.MakeMemberAccess(propertyAccess, prop);
                currentType = prop.PropertyType;
            }

            var orderByExp = Expression.Lambda(propertyAccess, parameter);

            string methodName = dir == "desc" ? "OrderByDescending" : "OrderBy";

            var resultExp = Expression.Call(
                typeof(Queryable),
                methodName,
                new Type[] { entityType, currentType },
                query.Expression,
                Expression.Quote(orderByExp));

            return query.Provider.CreateQuery<T>(resultExp);
        }

    }
}