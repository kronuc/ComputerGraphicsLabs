namespace ComputerGraphicsLabs.Models.ComputeObjects
{
    public class Vector
    {
        public Coordinates Coordinates { get; set; }

        public Vector(Coordinates coordinates)
        {
            Coordinates = coordinates;
        }
    }
}
