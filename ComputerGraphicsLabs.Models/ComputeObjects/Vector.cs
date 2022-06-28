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
            var xSquere = Math.Pow(Coordinates.XCoordinate, 2);
            var ySquere = Math.Pow(Coordinates.YCoordinate, 2);
            var zSquere = Math.Pow(Coordinates.ZCoordinate, 2);
            var result = Math.Pow(xSquere + ySquere + zSquere, 0.5);
            return result;
        }

        public static Vector CreateVectorByTwoPoints(Point start, Point end)
        {
            var startPointCoord = start.Coordinates;
            var endPointCoord = end.Coordinates;
            var x = endPointCoord.XCoordinate - startPointCoord.XCoordinate;
            var y = endPointCoord.YCoordinate - startPointCoord.YCoordinate;
            var z = endPointCoord.ZCoordinate - startPointCoord.ZCoordinate;
            var coordinatesOfResult = new Coordinates(x, y, z);
            var result = new Vector(coordinatesOfResult);
            return result;
        }

        public static Vector Cross(Vector v, Vector u)
        {
            var vCoord = v.Coordinates;
            var uCoord = u.Coordinates;
            var newX = vCoord.YCoordinate * uCoord.ZCoordinate - vCoord.ZCoordinate * uCoord.YCoordinate;
            var newY = vCoord.ZCoordinate * uCoord.XCoordinate - vCoord.XCoordinate * uCoord.ZCoordinate;
            var newZ = vCoord.XCoordinate * uCoord.YCoordinate - vCoord.YCoordinate * uCoord.XCoordinate;
            var coordinatesOfResult = new Coordinates(newX, newY, newZ);
            var result = new Vector(coordinatesOfResult);
            return result;

        }

        public static double Dot(Vector v, Vector u) 
        {
            var result = 0d;
            var vCoord = v.Coordinates;
            var uCoord = u.Coordinates;
            result += vCoord.XCoordinate * uCoord.XCoordinate;
            result += vCoord.YCoordinate * uCoord.YCoordinate;
            result += vCoord.ZCoordinate * uCoord.ZCoordinate;
            return result;
        }

        public static Vector operator -(Vector v) => v * (-1d);

        public static Vector operator *(Vector v, double d)
        {
            var vCoord = v.Coordinates;
            var x = d * vCoord.XCoordinate;
            var y = d * vCoord.YCoordinate;
            var z = d * vCoord.ZCoordinate;
            var resultCoordinates = new Coordinates(x, y, z);
            var result = new Vector(resultCoordinates);
            return result;
        }

        public static Vector operator /(Vector v, double d) => v * (1 / d);

        public static Vector operator +(Vector v, Vector u)
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

        public static Vector operator +(Vector v, Point p)
        {
            var vCoord = v.Coordinates;
            var pCoord = p.Coordinates;
            var x = vCoord.XCoordinate + pCoord.XCoordinate;
            var y = vCoord.XCoordinate + pCoord.YCoordinate;
            var z = vCoord.XCoordinate + pCoord.ZCoordinate;
            var resultCoordinates = new Coordinates(x, y, z);
            var result = new Vector(resultCoordinates);
            return result;
        }
    }
}
