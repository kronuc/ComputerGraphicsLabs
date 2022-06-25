using System;

namespace ComputerGraphicsLabs.Models.ComputeObjects
{
    public class Vector
    {
        public Coordinates Coordinates { get; set; }

        public Vector(Coordinates coordinates)
        {
            Coordinates = coordinates;
        }

        public double GetModule()
        {
            var xSquere = Math.Pow(Coordinates.XCoorinate, 2);
            var ySquere = Math.Pow(Coordinates.YCoorinate, 2);
            var zSquere = Math.Pow(Coordinates.ZCoorinate, 2);
            var result = Math.Pow(xSquere + ySquere + zSquere, 0.5);
            return result;
        }

        public static Vector CreateVectorByTwoPoints(Point start, Point end)
        {
            var startPointCoord = start.Coordinates;
            var endPointCoord = end.Coordinates;
            var x = endPointCoord.XCoorinate - startPointCoord.XCoorinate;
            var y = endPointCoord.YCoorinate - startPointCoord.YCoorinate;
            var z = endPointCoord.ZCoorinate - startPointCoord.ZCoorinate;
            var coordinatesOfResult = new Coordinates(x, y, z);
            var result = new Vector(coordinatesOfResult);
            return result;
        }

        public static Vector Cross(Vector v, Vector u)
        {
            var vCoord = v.Coordinates;
            var uCoord = u.Coordinates;
            var newX = vCoord.YCoorinate * uCoord.ZCoorinate - vCoord.ZCoorinate * uCoord.YCoorinate;
            var newY = vCoord.ZCoorinate * uCoord.XCoorinate - vCoord.XCoorinate * uCoord.ZCoorinate;
            var newZ = vCoord.XCoorinate * uCoord.YCoorinate - vCoord.YCoorinate * uCoord.XCoorinate;
            var coordinatesOfResult = new Coordinates(newX, newY, newZ);
            var result = new Vector(coordinatesOfResult);
            return result;

        }

        public static double Dot(Vector v, Vector u) 
        {
            var result = 0d;
            var vCoord = v.Coordinates;
            var uCoord = u.Coordinates;
            result += vCoord.XCoorinate * uCoord.XCoorinate;
            result += vCoord.YCoorinate * uCoord.YCoorinate;
            result += vCoord.ZCoorinate * uCoord.ZCoorinate;
            return result;
        }

        public static Vector operator -(Vector v) => v * (-1d);

        public static Vector operator *(Vector v, double d)
        {
            var vCoord = v.Coordinates;
            var x = d * vCoord.XCoorinate;
            var y = d * vCoord.YCoorinate;
            var z = d * vCoord.ZCoorinate;
            var resultCoordinates = new Coordinates(x, y, z);
            var result = new Vector(resultCoordinates);
            return result;
        }

        public static Vector operator /(Vector v, double d) => v * (1 / d);

        public static Vector operator +(Vector v, Vector u)
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

        public static Vector operator +(Vector v, Point p)
        {
            var vCoord = v.Coordinates;
            var pCoord = p.Coordinates;
            var x = vCoord.XCoorinate + pCoord.XCoorinate;
            var y = vCoord.XCoorinate + pCoord.YCoorinate;
            var z = vCoord.XCoorinate + pCoord.ZCoorinate;
            var resultCoordinates = new Coordinates(x, y, z);
            var result = new Vector(resultCoordinates);
            return result;
        }
    }
}
