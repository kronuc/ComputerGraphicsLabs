using ComputerGraphicsLabs.Models.ComputeObjects;

namespace ComputerGraphicsLabs.Models.MainObjects
{
    public class Light
    {
        public Point Origin { get; private set; }

        public Light(Point coordinates)
        {
            Origin = coordinates;
        }

        public Vector GetvectorFromPointToLight(Point point)
        {
            return Vector.CreateVectorByTwoPoints(Origin, point);
        }
    }
}
