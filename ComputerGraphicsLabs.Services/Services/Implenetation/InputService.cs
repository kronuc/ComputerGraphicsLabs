using ComputerGraphicsLabs.Models.ComputeObjects;
using ComputerGraphicsLabs.Models.VisibleObjects;
using ComputerGraphicsLabs.Services.Services.Abstracion;
using System.Collections.Generic;

namespace ComputerGraphicsLabs.Services.Services.Implenetation
{
    public class InputService : IInputService
    {
        public List<VisibleObject> GetVisibleObjects()
        {
            return new List<VisibleObject>()
            {
                new Sphere(new Coordinates(1300, 0, 0), 200)
            };
        }
    }
}
