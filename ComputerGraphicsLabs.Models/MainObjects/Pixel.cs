namespace ComputerGraphicsLabs.Models.MainObjects
{
    public class Pixel
    {
        public Collors Color { get; private set; }

        public Pixel(Collors color)
        {
            Color = color;
        }
    }
}
