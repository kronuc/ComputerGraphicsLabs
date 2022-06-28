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

        public double[,] Body { get => _body; }


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
            vCoord.XCoordinate = result[0] / result[3];
            vCoord.YCoordinate = result[1] / result[3];
            vCoord.ZCoordinate = result[2] / result[3];
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
                matrix.Body[i, i] = mult;
            matrix.Body[3, 3] = 1;
            return matrix;
        }

        public static Matrix TurningX(double angle)
        {
            var matrix = new Matrix();

            var cos = Math.Cos(angle);
            var sin = Math.Sin(angle);

            matrix.Body[0, 0] = 1;
            matrix.Body[1, 1] = cos;
            matrix.Body[1, 2] = -sin;
            matrix.Body[2, 1] = sin;
            matrix.Body[2, 2] = cos;
            matrix.Body[3, 3] = 1;

            return matrix;
        }

        public static Matrix TurningY(double angle)
        {
            var matrix = new Matrix();

            var cos = Math.Cos(angle);
            var sin = Math.Sin(angle);

            matrix.Body[0, 0] = cos;
            matrix.Body[0, 2] = sin;
            matrix.Body[1, 1] = 1;
            matrix.Body[2, 0] = -sin;
            matrix.Body[2, 2] = cos;
            matrix.Body[3, 3] = 1;

            return matrix;
        }

        public static Matrix TurningZ(double angle)
        {
            var matrix = new Matrix();

            var cos = Math.Cos(angle);
            var sin = Math.Sin(angle);

            matrix.Body[0, 0] = cos;
            matrix.Body[0, 1] = -sin;
            matrix.Body[1, 0] = sin;
            matrix.Body[1, 1] = cos;
            matrix.Body[2, 2] = 1;
            matrix.Body[3, 3] = 1;

            return matrix;
        }

        public static Matrix Moving(double moveX, double moveY, double moveZ)
        {
            var matrix = new Matrix();
            var xyz = new double[3] { moveX, moveY, moveZ };
            for (int i =0; i < 4; i++) matrix.Body[i, i] = 1;
            for (int i = 0; i < 3; i++) matrix.Body[i, 3] = xyz[i];
            return matrix;
        }
    }
}
