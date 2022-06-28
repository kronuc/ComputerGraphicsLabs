using ComputerGraphicsLabs.Models.ComputeObjects;
using System;

namespace ComputerGraphicsLabs.Models.Matrix
{
    public class Matrix
    {
        private readonly double[,] source = new double[4, 4];

        public Matrix()
        {

        }

        public double[,] Source => source;


        public void ApplyTo(Point point)
        {
            double[] vector4 = new double[] { point.Coordinates.XCoordinate, point.Coordinates.YCoordinate, point.Coordinates.ZCoordinate, 1 };
            double[] result = MultiplyBy(vector4);
            point.Coordinates.XCoordinate = result[0];
            point.Coordinates.YCoordinate = result[1];
            point.Coordinates.ZCoordinate = result[2];
        }

        public void ApplyTo(Vector vector)
        {
            double[] vector4 = new double[] { vector.Coordinates.XCoordinate, vector.Coordinates.YCoordinate, vector.Coordinates.ZCoordinate, 1 };
            double[] result = MultiplyBy(vector4);
            vector.Coordinates.XCoordinate = result[0];
            vector.Coordinates.YCoordinate = result[1];
            vector.Coordinates.ZCoordinate = result[2];
        }

        public double[] MultiplyBy(double[] vector4)
        {
            double[] result = new double[] { 0, 0, 0, 0 };
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < vector4.Length; j++)
                {
                    result[i] += source[i, j] * vector4[j];
                }
            }

            return result;
        }
        public static Matrix Scaling(double multiplier)
        {
            Matrix matrix = new Matrix();
            matrix.Source[0, 0] = multiplier;
            matrix.Source[1, 1] = multiplier;
            matrix.Source[2, 2] = multiplier;
            matrix.Source[3, 3] = 1;
            return matrix;
        }

        public static Matrix Rotation(Vector axis, double radians)
        {
            Matrix matrix = new Matrix();
            Vector unit = axis / axis.GetModule();
            var cos = Math.Cos(radians);
            var sin = Math.Sin(radians);
            var l = unit.Coordinates.XCoordinate;
            var m = unit.Coordinates.YCoordinate;
            var n = unit.Coordinates.ZCoordinate;

            matrix.Source[0, 0] = l * l * (1 - cos) + 1 * cos;
            matrix.Source[0, 1] = m * l * (1 - cos) - n * sin;
            matrix.Source[0, 2] = n * l * (1 - cos) + m * sin;
            matrix.Source[1, 0] = l * m * (1 - cos) + n * sin;
            matrix.Source[1, 1] = m * m * (1 - cos) + 1 * cos;
            matrix.Source[1, 2] = n * m * (1 - cos) - l * sin;
            matrix.Source[2, 0] = l * n * (1 - cos) - m * sin;
            matrix.Source[2, 1] = m * n * (1 - cos) + l * sin;
            matrix.Source[2, 2] = n * n * (1 - cos) + 1 * cos;
            matrix.Source[3, 3] = 1;

            return matrix;
        }

        public static Matrix Transition(double offsetX, double offsetY, double offsetZ)
        {
            Matrix matrix = new Matrix();

            matrix.Source[0, 0] = 1;
            matrix.Source[1, 1] = 1;
            matrix.Source[2, 2] = 1;
            matrix.Source[3, 3] = 1;
            matrix.Source[3, 0] = offsetX;
            matrix.Source[3, 1] = offsetY;
            matrix.Source[3, 2] = offsetZ;

            return matrix;
        }
    }
}
