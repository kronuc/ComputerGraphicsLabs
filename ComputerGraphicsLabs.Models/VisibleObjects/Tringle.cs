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

        public Vector NormalA { get; set; }
        public Vector NormalB { get; set; }
        public Vector NormalC { get; set; }

        public Tringle(Point aPoint, Point bPoint, Point cPoint)
        {
            APoint = aPoint;
            BPoint = bPoint;
            CPoint = cPoint;
        }


        public Tringle(Point aPoint, Point bPoint, Point cPoint, Vector normalA, Vector normalB, Vector normalC)
        {
            APoint = aPoint;
            BPoint = bPoint;
            CPoint = cPoint;
            NormalA = normalA;
            NormalB = normalB;
            NormalC = normalC;
        }

        public override IntersecitonInfo Getintersection(Ray ray)
        {
            var rayDirection = ray.Direction;
            var rayOrigin = ray.Origin;
            var planePoint = APoint;
            
            var normal = Vector.Cross(Vector.CreateVectorByTwoPoints(APoint, BPoint), Vector.CreateVectorByTwoPoints(APoint, CPoint));
            if (Vector.Dot(rayDirection, normal) == 0) return GetEmptyIntersectionInfo();
            
            var root = Vector.Dot(planePoint - rayOrigin, normal) / Vector.Dot(rayDirection, normal);
            if (root <= 0) return GetEmptyIntersectionInfo();

            var vectorToIntersecitonPoint = rayDirection * root;
            var pointOfInterseciton = GetPointOfInterseciton(vectorToIntersecitonPoint, ray);
            if (!IsPointBelongToTringle(pointOfInterseciton)) return GetEmptyIntersectionInfo();

            var distanceToIntersection = vectorToIntersecitonPoint.GetModule();
            var normalWithLenghtOne = GetVectorWithLenghtOne(normal);

            return new IntersecitonInfo(pointOfInterseciton, distanceToIntersection, normalWithLenghtOne);
        }
        private bool IsPointBelongToTringle(Point point)
        {
            var ApB = GetAreaOfTringle(APoint, point, BPoint);
            var CpB = GetAreaOfTringle(CPoint, point, BPoint);
            var ApC = GetAreaOfTringle(APoint, point, CPoint);
            var ABC = GetAreaOfTringle(APoint, BPoint, CPoint);

            var equesionResult = Math.Abs(ApB + CpB + ApC - ABC);

            var result = equesionResult <= ACCURACY;

            return result;
        }

        private double GetAreaOfTringle(Point point_1, Point point_2, Point point_3) {
            var a = Vector.CreateVectorByTwoPoints(point_1, point_2).GetModule();
            var b = Vector.CreateVectorByTwoPoints(point_1, point_3).GetModule();
            var c = Vector.CreateVectorByTwoPoints(point_3, point_2).GetModule();

            var p = (a + b + c) / 2; 

            return Math.Pow(p * (p - a) * (p - b) * (p - c), 0.5); 
        }

    }
}
