using ComputerGraphicsLabs.Models.VisibleObjects;
using System.Collections.Generic;

namespace ComputerGraphicsLabs.Services.Services.Abstracion
{
    public interface IInputService
    {
        public List<VisibleObject> GetVisibleObjects();
    }
}
