using ComputerGraphicsLabs.Models.ComputeObjects;
using ComputerGraphicsLabs.Models.MainObjects.InfoObjects;
using System;

namespace ComputerGraphicsLabs.Models.VisibleObjects
{
    public class Sphere : VisibleObject
    {
        public Coordinates Center { get; private set; }
        public float Radius { get; private set; }

        public Sphere(Coordinates center, float radius)
        {
            Center = center;
            Radius = radius;
        }

        public override IntersecitonInfo Getintersection(Ray ray)
        {
            var oc = (new Point(Center)) - (new Point(ray.Origin));
            var a = Vector.Dot(ray.Direction, ray.Direction);
            var b = 2d * Vector.Dot(oc, ray.Direction);
            var c = Vector.Dot(oc, oc) - Radius * Radius;

            var discriminant = b * b - 4 * a * c;

            if (discriminant < 0)
                return new IntersecitonInfo(null, -1, null);

            var sqrtD = MathF.Sqrt((float)discriminant);
            var root = (b - sqrtD) / (2 * a);

            var vectorToIntersecitonPoint = ray.Direction * root;
            
            var pointOfInterseciton = new Coordinates(
                vectorToIntersecitonPoint.Coordinates.XCoorinate + ray.Origin.XCoorinate,
                vectorToIntersecitonPoint.Coordinates.YCoorinate + ray.Origin.YCoorinate,
                vectorToIntersecitonPoint.Coordinates.ZCoorinate + ray.Origin.ZCoorinate
                );

            var distanceToIntersection = vectorToIntersecitonPoint.GetModule();
            var normal = new Vector(new Coordinates(pointOfInterseciton.XCoorinate - Center.XCoorinate,
                pointOfInterseciton.YCoorinate - Center.YCoorinate,
                pointOfInterseciton.ZCoorinate - Center.ZCoorinate));
            var divider = normal.GetModule();
            var normalWithLenghtOne = new Vector(new Coordinates(normal.Coordinates.XCoorinate / divider,
                normal.Coordinates.YCoorinate / divider,
                normal.Coordinates.ZCoorinate / divider));
            var lenght = normalWithLenghtOne.GetModule();
            return new IntersecitonInfo(pointOfInterseciton, distanceToIntersection, normalWithLenghtOne);
        }
    }

    
}
