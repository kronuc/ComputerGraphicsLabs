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

        public Vector GetvectorFromPointToLight(Point point)
        {
            return new Vector(new Coordinates(
                Coordinates.XCoorinate - point.Coordinates.XCoorinate,
                Coordinates.YCoorinate - point.Coordinates.YCoorinate,
                Coordinates.ZCoorinate - point.Coordinates.ZCoorinate));
        }
    }
}
