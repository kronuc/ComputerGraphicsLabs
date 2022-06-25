using ComputerGraphicsLabs.Models.ComputeObjects;
using ComputerGraphicsLabs.Models.MainObjects;
using ComputerGraphicsLabs.Models.MainObjects.InfoObjects;

namespace ComputerGraphicsLabs.Models.InfoObjects.MainObjects
{
    public class Pixel
    {
        public bool HasIntersection { get => DistanceToIntesection > 0; }
        public double DistanceToIntesection { get; private set; }
        public double DistanceFromIntersectionToLight { get; private set; }
        public double AngleBeetwinLightAndViewRay { get; private set; }

        public Pixel(double distanceToIntesection, double distanceFromIntersectionToLight, double angleBeetwinLightAndViewRay)
        {
            DistanceToIntesection = distanceToIntesection;
            DistanceFromIntersectionToLight = distanceFromIntersectionToLight;
            AngleBeetwinLightAndViewRay = angleBeetwinLightAndViewRay;
        }


        public static Pixel CreatePixelFromIntersection(IntersecitonInfo interseciton, Light light)
        {
            var result = new Pixel(-1, 0, 0);

            if (!interseciton.HasIntersecion) return result;

            var normal = interseciton.Normal;

            var distanceToIntersection = interseciton.DistanceToInterseciton;

            var pointOfIntersection = interseciton.CoordinatesOfIntersection;
            var fromPointToLight = Vector.CreateVectorByTwoPoints(pointOfIntersection, light.Origin);
            var distanceToLight = fromPointToLight.GetModule();

            var scalarMultiply = Vector.Dot(fromPointToLight, normal);
            var angle = scalarMultiply / fromPointToLight.GetModule();

            result = new Pixel(distanceToIntersection, distanceToLight, angle);
           
            return result;
        }
    }
}
