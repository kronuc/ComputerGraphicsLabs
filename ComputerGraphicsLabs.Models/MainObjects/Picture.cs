using ComputerGraphicsLabs.Models.InfoObjects.MainObjects;

namespace ComputerGraphicsLabs.Models.MainObjects
{
    public class Picture
    {
        public Pixel[,] Pixels { get; private set; }

        public Picture(int pixelInHeight, int pixelInWidth)
        {
            Pixels = new Pixel[pixelInHeight, pixelInWidth];
        }
    }
}
