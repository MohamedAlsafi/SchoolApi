﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Wrapper
{
    public static class QueryableExtensions
    {
        public static async Task<PaginatedResult<T>> ToPaginatedListAsync<T>(
            this IQueryable<T> source, int pageNumber, int pageSize) where T : class
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
    }

}
