using ComputerGraphicsLabs.Models.MainObjects;
using System;

namespace ComputerGraphicsLabs.Visualisation
{
    public interface IPainter
    {
        public void Paint(Pixel[,] picture);
    }
}
