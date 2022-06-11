using ComputerGraphicsLabs.Models.ComputeObjects;

namespace ComputerGraphicsLabs.Models.MainObjects
{
    public class Light
    {
        public Coordinates Coordinates { get; private set; }

        public Light(Coordinates coordinates)
        {
            Coordinates = coordinates;
        }

        public Vector GetLightVectorToPoing(Point point)
        {
            return null;
        }
    }
}
