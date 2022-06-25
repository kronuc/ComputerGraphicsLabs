namespace ComputerGraphicsLabs.Models.ComputeObjects
{
    public class Point
    {
        public Coordinates Coordinates { get; set; }

        public Point(Coordinates coordinates)
        {
            Coordinates = coordinates;
        }
        public static Point operator -(Point p)
        {
            var pCoord = p.Coordinates;
            var x = - pCoord.XCoorinate;
            var y = - pCoord.YCoorinate;
            var z = - pCoord.ZCoorinate;
            var resultCoord = new Coordinates(x, y, z);
            var resutl = new Point(resultCoord);
            return resutl;
        }

        public static Vector operator +(Point v, Point u)
        {
            var vCoord = v.Coordinates;
            var uCoord = u.Coordinates;
            var x = vCoord.XCoorinate + uCoord.XCoorinate;
            var y = vCoord.YCoorinate + uCoord.YCoorinate;
            var z = vCoord.ZCoorinate + uCoord.ZCoorinate;
            var resultCoordinates = new Coordinates(x, y, z);
            var result = new Vector(resultCoordinates);
            return result;
        }

        public static Vector operator -(Point v, Point u) => v + (-u);
    }
}
