using ComputerGraphicsLabs.Models.ComputeObjects;
using System.Drawing;

namespace ComputerGraphicsLabs.Models.MainObjects.InfoObjects
{
    public class IntersecitonInfo
    {
        public double DistanceToInterseciton { get; private set; }
        public bool HasIntersecion { get => DistanceToInterseciton > 0 && CoordinatesOfIntersection != null; }
        public Coordinates CoordinatesOfIntersection { get; private set; }
        public Vector Normal { get; private set; }

        public IntersecitonInfo(Coordinates coordinatesOfIntersection, double distanceToInterseciton, Vector normal)
        {
            CoordinatesOfIntersection = coordinatesOfIntersection;
            DistanceToInterseciton = distanceToInterseciton;
            Normal = normal;
        }
    }
}
