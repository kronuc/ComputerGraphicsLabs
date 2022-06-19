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
    }
}
