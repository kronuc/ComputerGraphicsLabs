using ComputerGraphicsLabs.Services.Abstracion;
using ComputerGraphicsLabs.Services.Services.Implenetation;
using ComputerGraphicsLabs.Visualisation;
using Microsoft.Extensions.DependencyInjection;

namespace ComputerGraphicsLabs.Services
{
    public static class BootstrapExtention
    {
        public static IServiceCollection AddVisualisationServices(this IServiceCollection services)
        {
            services.AddPainter();
            services.AddSingleton<IVisualisationService, VisualisationService>();
            return services;
        }
    }
}
