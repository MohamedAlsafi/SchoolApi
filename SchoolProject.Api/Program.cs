
using Microsoft.EntityFrameworkCore;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure;
using SchoolProject.Services;
using SchoolProject.Core;
using SchoolProject.Api.Middlewares;
using School.Shared.Helper;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Microsoft.Extensions.Options;

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


            #region DenpendencyInjection
            builder.Services.AddInfrastructureDependencies()
                            .AddServicseDependencies()
                            .AddCoreDependencies();

            builder.Services.AddServiceRegistration(builder.Configuration);


            #endregion

            #region Localization
            builder.Services.AddControllers()
                            .AddDataAnnotationsLocalization();  
            builder.Services.AddLocalization(opt =>
            {
                opt.ResourcesPath = "Resources";
            });

            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                List<CultureInfo> supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("de-DE"),
                    new CultureInfo("fr-FR"),
                    new CultureInfo("ar-EG")
                };

                options.DefaultRequestCulture = new RequestCulture("en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });


            #endregion

            var app = builder.Build();

            var locOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);
            AutoMapperExtensions.Configure(app.Services);
            LZ.Configure(app.Services);
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
