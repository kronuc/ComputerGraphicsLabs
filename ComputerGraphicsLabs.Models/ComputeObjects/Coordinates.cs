namespace ComputerGraphicsLabs.Models.ComputeObjects
{
    public class Coordinates
    {
        double XCoorinate { get; set; } = 0;
        double YCoorinate { get; set; } = 0;
        double ZCoorinate { get; set; } = 0;

        public Coordinates(double xCoorinate, double yCoorinate, double zCoorinate)
        {
            XCoorinate = xCoorinate;
            YCoorinate = yCoorinate;
            ZCoorinate = zCoorinate;
        }

    }
}
