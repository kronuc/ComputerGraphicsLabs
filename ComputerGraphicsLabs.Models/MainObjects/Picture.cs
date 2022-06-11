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

        public Pixel[][] GetPicture()
        {
            return null;
        }
    }
}
