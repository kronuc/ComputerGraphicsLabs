using ComputerGraphicsLabs.Models.InfoObjects.MainObjects;
using ComputerGraphicsLabs.Models.MainObjects.InfoObjects;

namespace ComputerGraphicsLabs.Models.MainObjects
{
    public class LightManger
    {
        private Light _light;
        public LightManger() { }

        public void AddLight(Light light)
        {
            _light = light;
        }

        public Pixel GetPixelFromInterseciton(IntersecitonInfo intersecitonInfo)
        {
            return null;
        }
    }
}
