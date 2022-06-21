using ComputerGraphicsLabs.Models.InfoObjects.MainObjects;
using ComputerGraphicsLabs.Models.VisibleObjects;
using System.Collections.Generic;

namespace ComputerGraphicsLabs.Models.MainObjects
{
    public class Picture
    {
        public Light Light { get; private set; }
        public Viewer Viewer { get; private set; }
        public List<VisibleObject> VisibleObject { get; private set; }

        public Picture(Viewer viewer, Light light)
        {
            VisibleObject = new List<VisibleObject>();
            Viewer = viewer;
            Light = light;
        }

        public Pixel[,] GetPicture()
        {
            var pixels = new Pixel[Viewer.PixelInHeight, Viewer.PixelInWidth];
            for (int i = 0; i < Viewer.PixelInHeight; i++)
            {
                for (int j = 0; j < Viewer.PixelInWidth; j++)
                {
                    Viewer.GetRayForPixel(i, j);
                    pixels[i, j] = new Pixel(0,0,0);
                }
            }

            return pixels;
        }
    }
}
