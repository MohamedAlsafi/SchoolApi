using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Wrapper
{
    public static class QueryableExtensions
    {
        public static async Task<PaginatedResult<T>> ToPaginatedListAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize) where T : class
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            pageNumber = Math.Max(1, pageNumber);
            pageSize = Math.Max(1, pageSize);

            source = source.AsNoTracking();
            int count = await source.CountAsync();

            if (count == 0)
                return PaginatedResult<T>.Success(new List<T>(), 0, pageNumber, pageSize);

            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return PaginatedResult<T>.Success(items, count, pageNumber, pageSize);
        }


        public static IQueryable<T> ApplySearch<T>(this IQueryable<T> query, string? searchTerm, params string[] searchableProperties)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) || searchableProperties.Length == 0)
                return query;

            foreach (var prop in searchableProperties)
            {
                query = query.Where(x => EF.Property<string>(x, prop).Contains(searchTerm));
            }

            return query;
        }


        public static IQueryable<T> ApplyFiltering<T>(this IQueryable<T> query, Dictionary<string, object?> filters)
        {
            if (filters == null || filters.Count == 0)
                return query;

            foreach (var filter in filters)
            {
                if (filter.Value != null)
                    query = query.Where(x => EF.Property<object>(x, filter.Key).Equals(filter.Value));
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
