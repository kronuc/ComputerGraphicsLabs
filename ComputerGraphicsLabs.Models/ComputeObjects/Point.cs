namespace ComputerGraphicsLabs.Models.ComputeObjects
{
    public class Point
    {
        public Coordinates Coordinates { get; set; }

        public Point(Coordinates coordinates)
        {
            Coordinates = coordinates;
        }
        public static Point operator -(Point p) => new Point(
            new Coordinates(
                -p.Coordinates.XCoorinate,
                -p.Coordinates.YCoorinate,
                -p.Coordinates.ZCoorinate));

        public static Vector operator +(Point v, Point u) => new Vector(
            new Coordinates(
                v.Coordinates.XCoorinate + u.Coordinates.XCoorinate, 
                v.Coordinates.XCoorinate + u.Coordinates.YCoorinate, 
                v.Coordinates.XCoorinate + u.Coordinates.ZCoorinate));


        public static Vector operator -(Point v, Point u) => new Vector(
            new Coordinates(
                v.Coordinates.XCoorinate + u.Coordinates.XCoorinate,
                v.Coordinates.XCoorinate + u.Coordinates.YCoorinate,
                v.Coordinates.XCoorinate + u.Coordinates.ZCoorinate));
    }
}
