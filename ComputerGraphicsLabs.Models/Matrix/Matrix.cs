using ComputerGraphicsLabs.Models.ComputeObjects;
using System;

namespace ComputerGraphicsLabs.Models.Matrix
{
    public class Matrix
    {
        private readonly double[,] _body;

        public Matrix()
        {
            _body = new double[4, 4];
        }

        public double[,] Source { get => _body; }


        public void ApplyToPoint(Point point)
        {
            var pCoord = point.Coordinates;
            double[] vector4 = new double[] { pCoord.XCoordinate, pCoord.YCoordinate, pCoord.ZCoordinate, 1 };
            double[] result = MultiplyBy(vector4);
            pCoord.XCoordinate = result[0];
            pCoord.YCoordinate = result[1];
            pCoord.ZCoordinate = result[2];
        }

        public void ApplyToVector(Vector vector)
        {
            var vCoord = vector.Coordinates;
            double[] vector4 = new double[] { vCoord.XCoordinate, vCoord.YCoordinate, vCoord.ZCoordinate, 1 };
            double[] result = MultiplyBy(vector4);
            vCoord.XCoordinate = result[0];
            vCoord.YCoordinate = result[1];
            vCoord.ZCoordinate = result[2];
        }

        private double[] MultiplyBy(double[] vector4)
        {
            double[] result = new double[4]; 
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < vector4.Length; j++)
                {
                    result[i] += _body[i, j] * vector4[j];
                }
            }

            return result;
        }

        public static Matrix Scaling(double mult)
        {
            Matrix matrix = new Matrix();
            for (int i = 0; i < 3; i++)
                matrix.Source[i, i] = mult;
            matrix.Source[3, 3] = 1;
            return matrix;
        }

        public static Matrix Turning(Vector axis, double angle)
        {
            var matrix = new Matrix();

            var cos = Math.Cos(angle);
            var sin = Math.Sin(angle);

            var unit = axis / axis.GetModule();
            var unitCoord = unit.Coordinates;
            var x = unitCoord.XCoordinate;
            var y = unitCoord.YCoordinate;
            var z = unitCoord.ZCoordinate;

            matrix.Source[0, 0] = x * x * (1 - cos) + 1 * cos;
            matrix.Source[0, 1] = y * x * (1 - cos) - z * sin;
            matrix.Source[0, 2] = z * x * (1 - cos) + y * sin;
            matrix.Source[1, 0] = x * y * (1 - cos) + z * sin;
            matrix.Source[1, 1] = y * y * (1 - cos) + 1 * cos;
            matrix.Source[1, 2] = z * y * (1 - cos) - x * sin;
            matrix.Source[2, 0] = x * z * (1 - cos) - y * sin;
            matrix.Source[2, 1] = y * z * (1 - cos) + x * sin;
            matrix.Source[2, 2] = z * z * (1 - cos) + 1 * cos;
            matrix.Source[3, 3] = 1;

            return matrix;
        }

        public static Matrix Moving(double moveX, double moveY, double moveZ)
        {
            var matrix = new Matrix();
            var xyz = new double[3] { moveX, moveY, moveZ };
            for (int i =0; i < 4; i++) matrix.Source[i, i] = 1;
            for (int i = 0; i < 3; i++) matrix.Source[3, i] = xyz[i];
            return matrix;
        }
    }
}
