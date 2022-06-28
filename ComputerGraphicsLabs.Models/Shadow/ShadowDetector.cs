using ComputerGraphicsLabs.Models.ComputeObjects;
using ComputerGraphicsLabs.Models.MainObjects;
using ComputerGraphicsLabs.Models.VisibleObjects;
using System.Collections.Generic;
using System.Linq;

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

            var vectorToLight = newPoint - light.Origin;
            var rayToLight = new Ray(newPoint, vectorToLight);
            var intersection = objects
                .AsParallel()
                .Select(visibleObject => visibleObject.Getintersection(rayToLight))
                .Where(intersection => intersection.HasIntersecion && intersection.Target != target)
                .FirstOrDefault();

            return intersection != null;
        }
    }
}
