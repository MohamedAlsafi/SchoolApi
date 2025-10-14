using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Infrastructure.Abstract;
using SchoolProject.Infrastructure.Implementaion;
using SchoolProject.Infrastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddScoped<IStudentReposetory, StudentReposetory>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}
