using ComputerGraphicsLabs.Models.ComputeObjects;
using ComputerGraphicsLabs.Models.MainObjects.InfoObjects;

namespace ComputerGraphicsLabs.Models.VisibleObjects
{
    public abstract class VisibleObject
    {
        public abstract IntersecitonInfo Getintersection(Ray ray);

        protected IntersecitonInfo GetEmptyIntersectionInfo() => new IntersecitonInfo(null, -1, null, this);

        protected Point GetPointOfInterseciton(Vector vectorToIntersecitonPoint, Ray ray)
        {
            var x = vectorToIntersecitonPoint.Coordinates.XCoordinate + ray.Origin.Coordinates.XCoordinate;
            var y = vectorToIntersecitonPoint.Coordinates.YCoordinate + ray.Origin.Coordinates.YCoordinate;
            var z = vectorToIntersecitonPoint.Coordinates.ZCoordinate + ray.Origin.Coordinates.ZCoordinate;

            var coordOfPointOfIntersection = new Coordinates(x, y, z);
            var result = new Point(coordOfPointOfIntersection);
            
            return result;
        }

        protected Vector GetVectorWithLenghtOne(Vector normal)
        {
            var divider = normal.GetModule();
            var normalWithLenghtOne = normal / divider;
            return normalWithLenghtOne;
        }

        protected Vector GetVectorToInterseciton(double t, Ray ray)
        {
            return ray.Direction * t;
        }
    }
}
