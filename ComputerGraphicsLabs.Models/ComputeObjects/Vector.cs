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
            return Math.Pow(Math.Pow(Coordinates.XCoorinate,2) + Math.Pow(Coordinates.YCoorinate,2) + Math.Pow(Coordinates.ZCoorinate,2), 0.5);
        }

        public static double Dot(Vector v, Vector u) 
        {
            var result = 0d;
            result += v.Coordinates.XCoorinate * u.Coordinates.XCoorinate;
            result += v.Coordinates.YCoorinate * u.Coordinates.YCoorinate;
            result += v.Coordinates.ZCoorinate * u.Coordinates.ZCoorinate;
            return result;
        }
            
        public static Vector operator -(Vector v) => new Vector(
            new Coordinates(
                -v.Coordinates.XCoorinate, 
                -v.Coordinates.YCoorinate, 
                -v.Coordinates.ZCoorinate));


        public static Vector operator *(Vector v, double d) => new Vector(
            new Coordinates(
                d * v.Coordinates.XCoorinate,
                d * v.Coordinates.YCoorinate,
                d * v.Coordinates.ZCoorinate));

        public static Vector operator +(Vector v, Vector u) => new Vector(
            new Coordinates(
                v.Coordinates.XCoorinate + u.Coordinates.XCoorinate, 
                v.Coordinates.XCoorinate + u.Coordinates.YCoorinate, 
                v.Coordinates.XCoorinate + u.Coordinates.ZCoorinate));

        public static Vector operator +(Vector v, Point p) => new Vector(
            new Coordinates(
                v.Coordinates.XCoorinate + p.Coordinates.XCoorinate,
                v.Coordinates.XCoorinate + p.Coordinates.YCoorinate,
                v.Coordinates.XCoorinate + p.Coordinates.ZCoorinate));
    }
}
