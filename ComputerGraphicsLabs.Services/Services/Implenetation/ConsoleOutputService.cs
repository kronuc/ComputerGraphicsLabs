using ComputerGraphicsLabs.Models.MainObjects;
using ComputerGraphicsLabs.Services.Services.Abstracion;
using System;

namespace ComputerGraphicsLabs.Services.Services.Implenetation
{
    public class ConsoleOutputService : IOutputService
    {
        public void DrawPicture(Picture picture)
        {
            var pixels = picture.Pixels;
            var result = "";
            var rows = pixels.GetUpperBound(0) + 1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < pixels.Length / rows; j++)
                {
                    var pixel = pixels[i, j];
                    if (!pixel.HasIntersection || pixel.AngleBeetwinLightAndViewRay <=0) 
                    { 
                        result += " ";
                        continue;
                    }
                    if(pixel.AngleBeetwinLightAndViewRay > 0.8)
                    {
                        result += "-";
                        continue;
                    }

                    if (pixel.AngleBeetwinLightAndViewRay <= 0.2)
                    {
                        result += ".";
                        continue;
                    }
                    if (pixel.AngleBeetwinLightAndViewRay <= 0.5)
                    {
                        result += "*";
                        continue;
                    }
                    if (pixel.AngleBeetwinLightAndViewRay <= 0.8)
                    {
                        result += "O";
                        continue;
                    }
                }
                result += "\n";
            }
            Console.WriteLine(result);
        }
    }
}
