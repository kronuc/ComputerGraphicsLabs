namespace ComputerGraphicsLabs.Models.ComputeObjects
{
    public class Coordinates
    {
        public double XCoordinate { get; set; } = 0;
        public double YCoordinate { get; set; } = 0;
        public double ZCoordinate { get; set; } = 0;

        public Coordinates(double xCoorinate, double yCoorinate, double zCoorinate)
        {
            XCoordinate = xCoorinate;
            YCoordinate = yCoorinate;
            ZCoordinate = zCoorinate;
        }

    }
}
