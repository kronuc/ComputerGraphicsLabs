using ComputerGraphicsLabs.Models.ComputeObjects;
using ComputerGraphicsLabs.Models.MainObjects;
using ComputerGraphicsLabs.Models.MainObjects.InfoObjects;
using ComputerGraphicsLabs.Models.Shadow;
using ComputerGraphicsLabs.Models.VisibleObjects;
using System.Collections.Generic;

namespace ComputerGraphicsLabs.Models.InfoObjects.MainObjects
{
    public class Pixel
    {
        public bool HasShadow { get; private set; }
        public bool HasIntersection { get => DistanceToIntesection > 0; }
        public double DistanceToIntesection { get; private set; }
        public double DistanceFromIntersectionToLight { get; private set; }
        public double AngleBeetwinLightAndViewRay { get; private set; }

        public Pixel(double distanceToIntesection, double distanceFromIntersectionToLight, double angleBeetwinLightAndViewRay, bool hasShadow)
        {
            DistanceToIntesection = distanceToIntesection;
            DistanceFromIntersectionToLight = distanceFromIntersectionToLight;
            AngleBeetwinLightAndViewRay = angleBeetwinLightAndViewRay;
            HasShadow = hasShadow;
        }


        public static Pixel CreatePixelFromIntersection(IntersecitonInfo interseciton, Light light, List<VisibleObject> objects)
        {
            var result = new Pixel(-1, 0, 0, false);

            if (!interseciton.HasIntersecion) return result;

            var normal = interseciton.Normal;

            var distanceToIntersection = interseciton.DistanceToInterseciton;

            var pointOfIntersection = interseciton.CoordinatesOfIntersection;
            var fromPointToLight = Vector.CreateVectorByTwoPoints(pointOfIntersection, light.Origin);
            var distanceToLight = fromPointToLight.GetModule();

            var scalarMultiply = Vector.Dot(fromPointToLight, normal);
            var angle = scalarMultiply / fromPointToLight.GetModule();
            var hasShadow = ShadowDetector.HasShadow(pointOfIntersection, normal, light, objects, interseciton.Target);
            result = new Pixel(distanceToIntersection, distanceToLight, angle, hasShadow);
           
            return result;
        }
    }
}
