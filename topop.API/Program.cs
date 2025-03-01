
using Microsoft.EntityFrameworkCore;
using topop.Application.Services.Imp;
using topop.Application.Services;
using topop.Infrastructure;
using topop.Infrastructure.Repository.Imp;
using topop.Infrastructure.Repository.Interface;
using topop.Infrastructure.UnitOfWork.Imp;
using topop.Infrastructure.UnitOfWork.Interface;
using Microsoft.OpenApi.Models;

namespace topop.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configura la conexi�n a la base de datos.
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // UnitOfWork
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Repository
            builder.Services.AddScoped<IVideoRepository, VideoRepository>();

            // Service
            builder.Services.AddScoped<IVideoService, VideoService>();

            // AutoMapper
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

            // URL personalizada para HTTP
            builder.WebHost.UseUrls("http://localhost:5000");

            // Configuraci�n de los controladores
            builder.Services.AddControllers();

            // Configuraci�n de Swagger/OpenAPI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Configuraci�n de CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            // Crear la aplicaci�n
            var app = builder.Build();

            // Configurar la canalizaci�n de la solicitud HTTP.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Aplicar la pol�tica CORS
            app.UseCors("AllowAll");

            // Eliminar la redirecci�n HTTPS
            // No se necesita HTTPSRedirection ya que no usaremos HTTPS
            // app.UseHttpsRedirection();  <- Lo eliminamos

            // Habilitar la autorizaci�n
            app.UseAuthorization();

            // Mapear los controladores
            app.MapControllers();

            // Ejecutar la aplicaci�n
            app.Run();
        }
    }
}
