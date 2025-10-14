
using Microsoft.EntityFrameworkCore;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure;
using SchoolProject.Services;
using SchoolProject.Core;
using SchoolProject.Api.Middlewares;
using School.Shared.Helper;

namespace SchoolProject.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<SchoolDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            #region DenpendencyInjection
            builder.Services.AddInfrastructureDependencies()
                            .AddServicseDependencies()
                            .AddCoreDependencies();
            #endregion

            var app = builder.Build();

            AutoMapperExtensions.Configure(app.Services);
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
