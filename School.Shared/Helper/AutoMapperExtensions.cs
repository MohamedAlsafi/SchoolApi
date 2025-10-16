using AutoMapper.QueryableExtensions;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Shared.Helper
{
    public static class AutoMapperExtensions
    {
        private static IServiceProvider _serviceProvider;

        public static void Configure(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        //Add
        public static T Map<T>(this object source)
        {
            var mapper = _serviceProvider.GetRequiredService<IMapper>();
            return mapper.Map<T>(source);
        }

        //Update 
        public static TDestination Map<TSource, TDestination>(this TSource source, TDestination destination)
        {
            var mapper = _serviceProvider.GetRequiredService<IMapper>();
            return mapper.Map(source, destination);
        }

        // Read
        public static IQueryable<T> ProjectTo<T>(this IQueryable source)
        {
            var mapper = _serviceProvider.GetRequiredService<IMapper>();
            return source.ProjectTo<T>(mapper.ConfigurationProvider);
        }
    }

}
