using ComputerGraphicsLabs.Models.ComputeObjects;
using ComputerGraphicsLabs.Models.MainObjects.InfoObjects;
using System;

namespace ComputerGraphicsLabs.Models.VisibleObjects
{
    public class Tringle : VisibleObject
    {
        private const double ACCURACY = 0.001;
        
        public Point APoint { get; set; }
        public Point BPoint { get; set; }
        public Point CPoint { get; set; }

        public Vector Normal { get; set; }

        public Tringle(Point aPoint, Point bPoint, Point cPoint)
        {
            APoint = aPoint;
            BPoint = bPoint;
            CPoint = cPoint;
            Normal = Vector.Cross(CPoint - APoint, BPoint - APoint);
        }

        public Tringle(Point aPoint, Point bPoint, Point cPoint, Vector normalA)
        {
            APoint = aPoint;
            BPoint = bPoint;
            CPoint = cPoint;
            Normal = normalA;
        }

        public override IntersecitonInfo Getintersection(Ray ray)
        {
            var rayDirection = ray.Direction;
            var edge1 = BPoint - APoint;
            var edge2 = CPoint - APoint;

            var normalToRayAndEdge = Vector.Cross(ray.Direction , edge2);
            var det = Vector.Dot(normalToRayAndEdge, edge1);

            if (det < ACCURACY) return GetEmptyIntersectionInfo();

            var fromAtoLight = ray.Origin - APoint;
            var u = Vector.Dot(normalToRayAndEdge, fromAtoLight) / det;
            if (u < 0.0 || u > 1.0) return GetEmptyIntersectionInfo();

            var q = Vector.Cross(fromAtoLight, edge1);
            var v = Vector.Dot(q, rayDirection) / det;
            if (v < 0.0 || u + v > 1.0) return GetEmptyIntersectionInfo();

            var root = Vector.Dot(q, edge2) / det;

            var vectorToIntersecitonPoint = rayDirection * root;
            var pointOfInterseciton = GetPointOfInterseciton(vectorToIntersecitonPoint, ray);

            var distanceToIntersection = vectorToIntersecitonPoint.GetModule();
            var normalWithLenghtOne = GetVectorWithLenghtOne(Normal);

            return new IntersecitonInfo(pointOfInterseciton, distanceToIntersection, normalWithLenghtOne, this);
        }
    }
}
