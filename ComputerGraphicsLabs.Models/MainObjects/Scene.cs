using ComputerGraphicsLabs.Models.ComputeObjects;
using ComputerGraphicsLabs.Models.InfoObjects.MainObjects;
using ComputerGraphicsLabs.Models.MainObjects.InfoObjects;
using ComputerGraphicsLabs.Models.VisibleObjects;
using System.Collections.Generic;

namespace ComputerGraphicsLabs.Models.MainObjects
{
    public class Scene
    {
        public Light Light { get; private set; }
        public Viewer Viewer { get; private set; }
        public List<VisibleObject> VisibleObject { get; private set; }

        public Scene(Viewer viewer, Light light)
        {
            VisibleObject = new List<VisibleObject>();
            Viewer = viewer;
            Light = light;
        }

        public Picture GetPicture()
        {
            var picture = new Picture(Viewer.PixelInHeight, Viewer.PixelInWidth);
            var pixels = picture.Pixels;
            var rows = pixels.GetUpperBound(0) + 1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < pixels.Length / rows; j++)
                {
                    var ray = Viewer.GetRayForPixel(j, i);
                    var isFirst = true;
                    var intersection = new IntersecitonInfo(null, -1, null);
                    foreach(var visibleObject in VisibleObject)
                    {
                        var newIntersection = visibleObject.Getintersection(ray);
                        if(isFirst)
                        {
                            intersection = newIntersection;
                            isFirst = false;
                        }
                        if(intersection.CoordinatesOfIntersection == null || newIntersection.DistanceToInterseciton <= intersection.DistanceToInterseciton)
                        {
                            intersection = newIntersection;
                        }
                    }

                    pixels[i, j] = CreatePixelFromIntersection(intersection);
                }
            }
            
            return picture;
        }

        private Pixel CreatePixelFromIntersection(IntersecitonInfo interseciton)
        {
            var result = new Pixel(-1, 0, 0);
            if (!interseciton.HasIntersecion) return result;
            var normal = interseciton.Normal;
            var fromPointToLight = CreateVectorByTwoPoints(interseciton.CoordinatesOfIntersection, Light.Coordinates);
            var scalarMultiply = Vector.Dot(fromPointToLight, normal);
            result = new Pixel(interseciton.DistanceToInterseciton, fromPointToLight.GetModule(), scalarMultiply/fromPointToLight.GetModule());
            return result;
        }

        private Vector CreateVectorByTwoPoints(Coordinates start, Coordinates end)
        {
            var coordinates = new Coordinates(end.XCoorinate - start.XCoorinate,
                end.YCoorinate - start.YCoorinate,
                end.ZCoorinate - start.ZCoorinate);
            return new Vector(coordinates);
        }
    }
}
