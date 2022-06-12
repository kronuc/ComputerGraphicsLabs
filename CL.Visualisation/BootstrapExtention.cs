using Microsoft.Extensions.DependencyInjection;

namespace ComputerGraphicsLabs.Visualisation
{
    public static class BootstrapExtention
    {
        public static IServiceCollection AddPainter(this IServiceCollection services)
        {
            services.AddSingleton<IPainter, ConsolePainter>();
            return services;
        }
    }
}
