using ComputerGraphicsLabs.Models.ComputeObjects;
using ComputerGraphicsLabs.Models.MainObjects;
using ComputerGraphicsLabs.Models.VisibleObjects;
using System.Collections.Generic;

namespace ComputerGraphicsLabs.Models.Shadow
{
    public class ShadowDetector
    {
        private const double ACCURACY = 0.1;

        public static bool HasShadow(Point point, Vector nomal, Light light, List<VisibleObject> objects, VisibleObject target)
        {
            var devitionVector = (nomal / nomal.GetModule()) * ACCURACY;
            var newPoint = new Point(new Coordinates(-devitionVector.Coordinates.XCoordinate + point.Coordinates.XCoordinate,
                -devitionVector.Coordinates.YCoordinate + point.Coordinates.YCoordinate,
                -devitionVector.Coordinates.ZCoordinate + point.Coordinates.ZCoordinate));

            var vectorToLight = -(light.Origin - newPoint);
            var rayToLight = new Ray(newPoint, vectorToLight);
            foreach(var obj in objects)
            {
                if (obj.Getintersection(rayToLight).HasIntersecion && obj != target)
                    return true;
            }
            return false;
        }
    }
}
