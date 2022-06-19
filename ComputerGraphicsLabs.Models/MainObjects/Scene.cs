using ComputerGraphicsLabs.Models.InfoObjects.MainObjects;
using ComputerGraphicsLabs.Models.VisibleObjects;
using System.Collections.Generic;

namespace ComputerGraphicsLabs.Models.MainObjects
{
    class Scene
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

        public Pixel[,] GetPicture()
        {
            var pixels = new Pixel[Viewer.PixelInHeight, Viewer.PixelInWidth];
            
            return pixels;
        }
    }
}
