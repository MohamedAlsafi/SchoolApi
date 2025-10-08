using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Services.Abstract;
using SchoolProject.Services.Implementaion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services
{
    public static class ModuleServicseDependencies
    {
        public static IServiceCollection AddServicseDependencies(this IServiceCollection services) {

            services.AddScoped<IStudentServices, StudentServices>();
            return services;
        }
    }
}
