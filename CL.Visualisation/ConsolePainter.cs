using ComputerGraphicsLabs.Models.MainObjects;
using System;

namespace ComputerGraphicsLabs.Visualisation
{
    public class ConsolePainter : IPainter
    {
        public void Paint(Pixel[,] picture)
        {
            var result = "";
            var rows = picture.GetUpperBound(0) + 1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < picture.Length / rows; j++)
                {
                    var pixel = picture[i, j];
                    switch (pixel.Color)
                    {
                        case Collors.White:
                            result += " ";
                            break;
                        case Collors.Gray:
                            result += "*";
                            break;
                        case Collors.Black:
                            result += "#";
                            break;
                        default:
                            result += " ";
                            break;
                    }
                }
                result += "\n";
            }
            Console.WriteLine(result);
        }
    }
}
