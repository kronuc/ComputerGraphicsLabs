using ComputerGraphicsLabs.Models.VisibleObjects;
using ComputerGraphicsLabs.Services;
using ComputerGraphicsLabs.Services.Abstracion;
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


            vs.AddVisibleObjects(new Tringle());
            vs.Visualise();
        }
    }
}
