using ComputerGraphicsLabs.Models.ComputeObjects;
using ComputerGraphicsLabs.Models.MainObjects;
using ComputerGraphicsLabs.Models.MainObjects.InfoObjects;

namespace ComputerGraphicsLabs.Models.VisibleObjects
{
    public abstract class VisibleObject
    {
        public abstract IntersecitonInfo Getintersection(Ray ray);

        protected IntersecitonInfo GetEmptyIntersectionInfo() => new IntersecitonInfo(null, -1, null);

        protected Point GetPointOfInterseciton(Vector vectorToIntersecitonPoint, Ray ray)
        {
            var x = vectorToIntersecitonPoint.Coordinates.XCoorinate + ray.Origin.Coordinates.XCoorinate;
            var y = vectorToIntersecitonPoint.Coordinates.YCoorinate + ray.Origin.Coordinates.YCoorinate;
            var z = vectorToIntersecitonPoint.Coordinates.ZCoorinate + ray.Origin.Coordinates.ZCoorinate;

            var coordOfPointOfIntersection = new Coordinates(x, y, z);
            var result = new Point(coordOfPointOfIntersection);
            
            return result;
        }

        protected Vector GetNormalWithLenghtOne(Vector normal)
        {
            var divider = normal.GetModule();
            var normalWithLenghtOne = normal * (1 / divider);
            return normalWithLenghtOne;
        }

        protected Vector GetVectorToInterseciton(double t, Ray ray)
        {
            return ray.Direction * t;
        }
    }
}
