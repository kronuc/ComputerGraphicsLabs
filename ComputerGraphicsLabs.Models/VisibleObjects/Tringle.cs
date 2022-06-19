using ComputerGraphicsLabs.Models.ComputeObjects;
using ComputerGraphicsLabs.Models.MainObjects;
using ComputerGraphicsLabs.Models.MainObjects.InfoObjects;

namespace ComputerGraphicsLabs.Models.VisibleObjects
{
    public class Tringle : VisibleObject
    {
        public Point APoint { get; set; }
        public Point BPoint { get; set; }
        public Point CPoint { get; set; }

        public override IntersecitonInfo Getintersection(Ray ray, Light light)
        {
            throw new System.NotImplementedException();
        }
    }
}
