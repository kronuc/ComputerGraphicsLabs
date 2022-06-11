namespace ComputerGraphicsLabs.Models.ComputeObjects
{
    public class Ray
    {
        public Coordinates Origin { get; private set; }
        public Vector Direction { get; private set; }

        public Ray(Coordinates origin, Vector direcitoin)
        {
            Origin = origin;
            Direction = direcitoin;
        }
    }
}
