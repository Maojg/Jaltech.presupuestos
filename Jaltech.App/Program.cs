using Jaltech.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Jaltech.App
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices((context, services) =>
                {
                    var connectionString = context.Configuration.GetConnectionString("DefaultConnection");

                    services.AddDbContext<JaltechDbContext>(options =>
                        options.UseSqlServer(connectionString));

                    services.AddScoped<FormInicio>(); // Registrar el formulario de inicio
                    services.AddScoped<FormPresupuestos>(); // Aquí puedes registrar otros formularios por módulo.
                    
                });

            var app = builder.Build();
            ApplicationConfiguration.Initialize();

            using var scope = app.Services.CreateScope();
            var mainForm = scope.ServiceProvider.GetRequiredService<FormInicio>();
            Application.Run(mainForm);
        }
    }
}
