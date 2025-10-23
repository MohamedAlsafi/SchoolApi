using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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


        public static IQueryable<T> ApplySearch<T>(this IQueryable<T> query,string? searchTerm,params Expression<Func<T, string>>[] searchableProperties)
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


        public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> query,params Expression<Func<T, bool>>?[] filters)
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


        public static IQueryable<T> ApplySorting<T>(this IQueryable<T> query, string? sortBy, string? direction = "asc")
        {
            if (string.IsNullOrEmpty(sortBy))
                return query;

            bool descending = direction?.ToLower() == "desc";

            query = descending
                ? query.OrderByDescending(x => EF.Property<object>(x, sortBy))
                : query.OrderBy(x => EF.Property<object>(x, sortBy));

            return query;
        }
    }

}
