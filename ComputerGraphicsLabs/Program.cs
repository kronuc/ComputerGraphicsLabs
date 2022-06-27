using ComputerGraphicsLabs.Services;
using ComputerGraphicsLabs.Services.Abstracion;
using ComputerGraphicsLabs.Services.Services.Abstracion;
using Microsoft.Extensions.DependencyInjection;

namespace ComputerGraphicsLabs
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddVisualisationServices();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var vs = serviceProvider.GetService<IVisualisationService>();
            var outputService = serviceProvider.GetService<IOutputService>();
            var inputService = serviceProvider.GetService<IInputService>();
            var visibleObjects = inputService.GetVisibleObjects();
            vs.AddVisibleObjects(visibleObjects);
            var picture = vs.GetPicture();
            outputService.DrawPicture(picture);
        }
    }
}
