using ComputerGraphicsLabs.Models.VisibleObjects;

namespace ComputerGraphicsLabs.Services.Abstracion
{
    public interface IVisualisationService
    {
        public void AddVisibleObjects(VisibleObject visibleObject);
        public void Visualise();
    }
}
