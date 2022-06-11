using ComputerGraphicsLabs.Models.ComputeObjects;

namespace ComputerGraphicsLabs.Models.VisibleObjects
{
    public abstract class VisibleObject
    {
        public abstract Point Getintersection(Ray ray);
    }
}
