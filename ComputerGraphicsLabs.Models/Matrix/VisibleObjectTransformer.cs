using ComputerGraphicsLabs.Models.ComputeObjects;
using ComputerGraphicsLabs.Models.VisibleObjects;
using System.Collections.Generic;
using System.Linq;

namespace ComputerGraphicsLabs.Models.Matrix
{
    public class VisibleObjectTransformer
    {
        private static void Apply(IEnumerable<Tringle> figure, Matrix matrix, bool applyToNormals)
        {
            var points = figure.SelectMany(t => new Point[] { t.APoint, t.BPoint, t.CPoint }).Distinct();
            foreach (var point in points) matrix.ApplyToPoint(point);

            if (!applyToNormals) return;

            var normals = figure.Select(t => t.Normal).Distinct();
            foreach (var normal in normals) matrix.ApplyToVector(normal);

        }

        public static void Scale(IEnumerable<Tringle> figure, double multiplier)
        {
            Apply(figure, Matrix.Scaling(multiplier), false);
        }

        public static void Rotate(IEnumerable<Tringle> figure, Vector axis, double angle)
        {
            Apply(figure, Matrix.Turning(axis, angle), true);
        }

        public static void Transite(IEnumerable<Tringle> figure, double moveX, double moveY, double moveZ)
        {
            Apply(figure, Matrix.Moving(moveX, moveY, moveZ), false);
        }
    }
}
