using ComputerGraphicsLabs.Models.ComputeObjects;
using ComputerGraphicsLabs.Models.VisibleObjects;

namespace ComputerGraphicsLabs.Models.MainObjects.InfoObjects
{
    public class IntersecitonInfo
    {
        public VisibleObject Target { get; private set; }
        public double DistanceToInterseciton { get; private set; }
        public bool HasIntersecion { get => DistanceToInterseciton > 0 && CoordinatesOfIntersection != null; }
        public Point CoordinatesOfIntersection { get; private set; }
        public Vector Normal { get; private set; }

        public IntersecitonInfo(Point coordinatesOfIntersection, double distanceToInterseciton, Vector normal, VisibleObject target)
        {
            CoordinatesOfIntersection = coordinatesOfIntersection;
            DistanceToInterseciton = distanceToInterseciton;
            Normal = normal;
            Target = target;
        }
    }
}
