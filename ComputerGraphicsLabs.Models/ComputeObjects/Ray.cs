namespace ComputerGraphicsLabs.Models.ComputeObjects
{
    public class Ray
    {
        public Point Origin { get; private set; }
        public Vector Direction { get; private set; }

        public Ray(Point origin, Vector direcitoin)
        {
            Origin = origin;
            Direction = direcitoin;
        }
    }
}
