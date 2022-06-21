using ComputerGraphicsLabs.Models.VisibleObjects;
using ComputerGraphicsLabs.Services.Services.Abstracion;
using System.Collections.Generic;

namespace ComputerGraphicsLabs.Services.Services.Implenetation
{
    public class InputService : IInputService
    {
        public List<VisibleObject> GetVisibleObjects()
        {
            return new List<VisibleObject>();
        }
    }
}
