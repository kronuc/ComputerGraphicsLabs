using ComputerGraphicsLabs.Models.ComputeObjects;


namespace ComputerGraphicsLabs.Models.MainObjects.InfoObjects
{
    public class IntersecitonInfo
    {
        public double DistanceToInterseciton { get; private set; }
        public bool HasIntersecion { get => DistanceToInterseciton > 0 && CoordinatesOfIntersection != null; }
        public Point CoordinatesOfIntersection { get; private set; }
        public Vector Normal { get; private set; }

        public IntersecitonInfo(Point coordinatesOfIntersection, double distanceToInterseciton, Vector normal)
        {
            CoordinatesOfIntersection = coordinatesOfIntersection;
            DistanceToInterseciton = distanceToInterseciton;
            Normal = normal;
        }
    }
}
