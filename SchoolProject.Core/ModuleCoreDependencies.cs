using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core
{
    public static class ModuleCoreDependencies
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {
            services.AddMediatR(cnf => cnf.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());

            return services;
        }
    }
}