using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Reflection.PortableExecutable;
using ZipCodesServer.Data;
using ZipCodesServer.Repos;
using ZipCodesServer.Services;
using ZipCodesServer.Settings;

namespace ZipCodesServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.WithOrigins("*")
                            .AllowAnyHeader();
                    });
            });
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Zip codes API",
                    Description = "An ASP.NET Core Web API for getting zip codes",
                    Contact = new OpenApiContact
                    {
                        Name = "Ze Sousa",
                        Url = new Uri("https://www.linkedin.com/in/joseadesousa/")
                    }

                });
            });
            builder.Services.AddMemoryCache();
            builder.Services.AddHttpClient<ZipCodeService>((provider, httpClient) =>
            {

                httpClient.BaseAddress = new Uri("https://api.zippopotam.us");

            });
     

            builder.Services.Configure<CatalogDatabaseSettings>(builder.Configuration.GetSection(nameof(CatalogDatabaseSettings)));

            builder.Services.AddSingleton<ICatalogDatabaseSettings>(sp =>
                 sp.GetRequiredService<IOptions<CatalogDatabaseSettings>>().Value);

            builder.Services.AddTransient<IZipCodeContext, ZipCodeContext>();
            builder.Services.AddTransient<IZipCodeRepository, ZipCodeRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors();
            app.UseHttpsRedirection();

            app.UseAuthorization();
           
            app.MapControllers();

            app.Run();
        }
    }
}