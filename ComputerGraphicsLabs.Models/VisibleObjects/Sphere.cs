using ComputerGraphicsLabs.Models.ComputeObjects;

namespace ComputerGraphicsLabs.Models.VisibleObjects
{
    public class Sphere : VisibleObject
    {
        public Coordinates Center { get; set; }
        public double Radius { get; set; }

        public override Point Getintersection(Ray ray)
        {
            throw new System.NotImplementedException();
        }
    }
}
