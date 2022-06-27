using ComputerGraphicsLabs.Services.Abstracion;
using ComputerGraphicsLabs.Services.Services.Abstracion;
using ComputerGraphicsLabs.Services.Services.Implenetation;
using ComputerGraphicsLabs.Services.Services.Implenetation.Input.Default;
using ComputerGraphicsLabs.Services.Services.Implenetation.Output;
using Microsoft.Extensions.DependencyInjection;

namespace ComputerGraphicsLabs.Services
{
    public static class BootstrapExtention
    {
        public static IServiceCollection AddVisualisationServices(this IServiceCollection services)
        {
            services.AddSingleton<IInputService, InputService>();
            services.AddSingleton<IOutputService, PpmOutputService>();
            services.AddSingleton<IVisualisationService, VisualisationService>();
            return services;
        }
    }
}
