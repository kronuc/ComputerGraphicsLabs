using ComputerGraphicsLabs.Models.ComputeObjects;
using ComputerGraphicsLabs.Models.MainObjects;
using ComputerGraphicsLabs.Models.MainObjects.InfoObjects;

namespace ComputerGraphicsLabs.Models.VisibleObjects
{
    public class Plane : VisibleObject
    {
        public Plane(Point aPoint, Point bPoint, Point cPoint)
        {
            APoint = aPoint;
            BPoint = bPoint;
            CPoint = cPoint;
        }

        public Point APoint { get; set; }
        public Point BPoint { get; set; }
        public Point CPoint { get; set; }

        public override IntersecitonInfo Getintersection(Ray ray)
        {
            var rayDirection = ray.Direction;
            var RayOrigin = ray.Origin;
            var planePoint = APoint;

            var normal = Vector.Cross(Vector.CreateVectorByTwoPoints(APoint, BPoint), Vector.CreateVectorByTwoPoints(APoint, CPoint));
            if (Vector.Dot(rayDirection, normal) == 0) return GetEmptyIntersectionInfo();

            var root = Vector.Dot(planePoint - RayOrigin, normal) / Vector.Dot(rayDirection, normal);
            if (root <= 0) return GetEmptyIntersectionInfo();

            var vectorToIntersecitonPoint = GetVectorToInterseciton(root, ray);
            var pointOfInterseciton = GetPointOfInterseciton(vectorToIntersecitonPoint, ray);
            var distanceToIntersection = vectorToIntersecitonPoint.GetModule();
            var normalWithLenghtOne = GetVectorWithLenghtOne(normal);

            return new IntersecitonInfo(pointOfInterseciton, distanceToIntersection, normalWithLenghtOne);
        }
    }
}
