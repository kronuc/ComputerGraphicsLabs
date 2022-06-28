using ComputerGraphicsLabs.Models.ComputeObjects;
using ComputerGraphicsLabs.Models.Matrix;
using ComputerGraphicsLabs.Models.VisibleObjects;
using ComputerGraphicsLabs.Services;
using ComputerGraphicsLabs.Services.Abstracion;
using ComputerGraphicsLabs.Services.Services.Abstracion;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

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
            var visibleObjects = inputService.GetVisibleObjects().Select(obj => (Tringle)obj);

            VisibleObjectTransformer.Scale(visibleObjects, 40);
            VisibleObjectTransformer.RotateX(visibleObjects, 3.14 * 0.1);
            VisibleObjectTransformer.RotateY(visibleObjects, 3.14 * 0.1);
            VisibleObjectTransformer.RotateZ(visibleObjects, 3.14 * 0.8);
            VisibleObjectTransformer.Transite(visibleObjects, 0, 0, 0);
            vs.AddVisibleObjects(visibleObjects.Select(visibleObject => (VisibleObject)visibleObject).ToList());
            var picture = vs.GetPicture();
            outputService.DrawPicture(picture);
        }
    }
}
