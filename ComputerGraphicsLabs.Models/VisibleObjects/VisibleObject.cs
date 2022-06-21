using ComputerGraphicsLabs.Models.ComputeObjects;
using ComputerGraphicsLabs.Models.MainObjects;
using ComputerGraphicsLabs.Models.MainObjects.InfoObjects;

namespace ComputerGraphicsLabs.Models.VisibleObjects
{
    public abstract class VisibleObject
    {
        public abstract IntersecitonInfo Getintersection(Ray ray);
    }
}
