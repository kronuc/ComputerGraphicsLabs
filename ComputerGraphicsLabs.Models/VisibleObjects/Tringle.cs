using ComputerGraphicsLabs.Models.ComputeObjects;

namespace ComputerGraphicsLabs.Models.VisibleObjects
{
    public class Tringle : VisibleObject
    {
        public Point APoint { get; set; }
        public Point BPoint { get; set; }
        public Point CPoint { get; set; }

        public override Point Getintersection(Ray ray)
        {
            throw new System.NotImplementedException();
        }
    }
}
