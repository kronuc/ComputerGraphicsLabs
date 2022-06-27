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
            var x = - pCoord.XCoordinate;
            var y = - pCoord.YCoordinate;
            var z = - pCoord.ZCoordinate;
            var resultCoord = new Coordinates(x, y, z);
            var resutl = new Point(resultCoord);
            return resutl;
        }

        public static Vector operator +(Point v, Point u)
        {
            var vCoord = v.Coordinates;
            var uCoord = u.Coordinates;
            var x = vCoord.XCoordinate + uCoord.XCoordinate;
            var y = vCoord.YCoordinate + uCoord.YCoordinate;
            var z = vCoord.ZCoordinate + uCoord.ZCoordinate;
            var resultCoordinates = new Coordinates(x, y, z);
            var result = new Vector(resultCoordinates);
            return result;
        }

        public static Vector operator -(Point v, Point u) => v + (-u);
    }
}
