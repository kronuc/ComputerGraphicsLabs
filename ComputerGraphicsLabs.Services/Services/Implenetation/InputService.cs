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
                new Sphere(new Point(new Coordinates(1400, 0, 0)), 300),
                new Tringle(new Point(new Coordinates(1000, -200, 200)), new Point(new Coordinates(1400, 300, -100)), new Point(new Coordinates(1400, -300, -100)))
            };
        }
    }
}
