using ComputerGraphicsLabs.Models.ComputeObjects;
using ComputerGraphicsLabs.Models.MainObjects;
using ComputerGraphicsLabs.Models.MainObjects.InfoObjects;

namespace ComputerGraphicsLabs.Models.VisibleObjects
{
    public class Sphere : VisibleObject
    {
        public Coordinates Center { get; private set; }
        public double Radius { get; private set; }

        public Sphere(Coordinates center, double radius)
        {
            Center = center;
            Radius = radius;
        }

        public override IntersecitonInfo Getintersection(Ray ray, Light light)
        {
            throw new System.NotImplementedException();
        }

    }
}
