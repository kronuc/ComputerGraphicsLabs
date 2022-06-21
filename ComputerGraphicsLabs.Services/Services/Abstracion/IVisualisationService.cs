using ComputerGraphicsLabs.Models.MainObjects;
using ComputerGraphicsLabs.Models.VisibleObjects;
using System.Collections.Generic;

namespace ComputerGraphicsLabs.Services.Abstracion
{
    public interface IVisualisationService
    {
        public void AddVisibleObjects(List<VisibleObject> visibleObject);
        public Picture GetPicture();
    }
}
