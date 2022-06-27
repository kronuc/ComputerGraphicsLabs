using ComputerGraphicsLabs.Models.ComputeObjects;
using ComputerGraphicsLabs.Models.MainObjects.InfoObjects;
using System;

namespace ComputerGraphicsLabs.Models.VisibleObjects
{
    public class Sphere : VisibleObject
    {
        public Point Center { get; private set; }
        public float Radius { get; private set; }

        public Sphere(Point center, float radius)
        {
            Center = center;
            Radius = radius;
        }

        public override IntersecitonInfo Getintersection(Ray ray)
        {
            var rayDirection = ray.Direction;
            
            var vectorFormSphereCenterToOrigin = Center - ray.Origin;
            
            var rayDirectionSquere = Vector.Dot(rayDirection, rayDirection);
            
            var bEquationParam = 2 * Vector.Dot(vectorFormSphereCenterToOrigin, rayDirection);
            
            var cEquationParam = Vector.Dot(vectorFormSphereCenterToOrigin, vectorFormSphereCenterToOrigin) 
                - Radius * Radius;

            var discriminant = bEquationParam * bEquationParam - 4 * rayDirectionSquere * cEquationParam;

            if (discriminant < 0) return GetEmptyIntersectionInfo();

            var sqrtDEquationParam = Math.Pow(discriminant, 0.5);
            var root = (bEquationParam - sqrtDEquationParam) / (2 * rayDirectionSquere);

            var vectorToIntersecitonPoint = GetVectorToInterseciton(root, ray);

            var pointOfInterseciton = GetPointOfInterseciton(vectorToIntersecitonPoint, ray);

            var distanceToIntersection = vectorToIntersecitonPoint.GetModule();

            var normal = pointOfInterseciton - Center;

            var normalWithLenghtOne = GetVectorWithLenghtOne(normal);

            return new IntersecitonInfo(pointOfInterseciton, distanceToIntersection, normalWithLenghtOne);
        }
    }

    
}
