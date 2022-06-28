using ComputerGraphicsLabs.Models.ComputeObjects;
using ComputerGraphicsLabs.Models.VisibleObjects;
using System.Collections.Generic;
using System.Linq;

namespace ComputerGraphicsLabs.Models.Matrix
{
    public class VisibleObjectTransformer
    {
        private static void Apply(Tringle obj, Matrix matrix)
        {
            matrix.ApplyTo(obj.APoint);
            matrix.ApplyTo(obj.BPoint);
            matrix.ApplyTo(obj.CPoint);
        }

        private static void Apply(IEnumerable<Tringle> figure, Matrix matrix)
        {
            var vertices = figure.SelectMany(t => new Point[] { t.APoint, t.BPoint, t.CPoint }).Distinct();
            foreach (var vertex in vertices) matrix.ApplyTo(vertex);
        }

        #region Scale

        public static void Scale(Tringle obj, double multiplier)
        {
            Apply(obj, Matrix.Scaling(multiplier));
        }

        public static void Scale(IEnumerable<Tringle> figure, double multiplier)
        {
            Apply(figure, Matrix.Scaling(multiplier));
        }

        #endregion

        #region Rotate

        public static void Rotate(Tringle obj, Vector axis, double angle)
        {
            Apply(obj, Matrix.Rotation(axis, angle));
        }

        public static void Rotate(IEnumerable<Tringle> figure, Vector axis, double angle)
        {
            Apply(figure, Matrix.Rotation(axis, angle));
        }

        #endregion

        #region Transite

        public static void Transite(Tringle obj, double offsetX, double offsetY, double offsetZ)
        {
            Apply(obj, Matrix.Transition(offsetX, offsetY, offsetZ));
        }

        public static void Transite(IEnumerable<Tringle> figure, double offsetX, double offsetY, double offsetZ)
        {
            Apply(figure, Matrix.Transition(offsetX, offsetY, offsetZ));
        }

        #endregion
    }
}
