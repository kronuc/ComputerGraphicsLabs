using ComputerGraphicsLabs.Models.InfoObjects.MainObjects;
using ComputerGraphicsLabs.Models.MainObjects.InfoObjects;
using ComputerGraphicsLabs.Models.VisibleObjects;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var colums = pixels.Length / rows;

            for (int i = 0; i < pixels.Length; i++)
            {
                var x = i / colums;
                var y = i % colums;
                var ray = Viewer.GetRayForPixel(x, y);

                var intersection = VisibleObject
                    .AsParallel()
                    .Select(visibleObject => visibleObject.Getintersection(ray))
                    .Where(intersection => intersection.HasIntersecion)
                    .OrderBy(intersection => intersection.DistanceToInterseciton)
                    .FirstOrDefault();

                if(i % 1000 == 0)
                {
                    Console.WriteLine(i.ToString() + "\\" + pixels.Length.ToString());
                }

                if (intersection == default) intersection = new IntersecitonInfo(null, -1, null, null);
                
                pixels[x, y] = Pixel.CreatePixelFromIntersection(intersection, Light, VisibleObject);
            }
            
            return picture;
        }

    }
}
