using ComputerGraphicsLabs.Models.InfoObjects.MainObjects;
using ComputerGraphicsLabs.Models.MainObjects;
using ComputerGraphicsLabs.Models.Shadow;
using ComputerGraphicsLabs.Services.Services.Abstracion;
using System;
using System.Drawing;
using System.IO;

namespace ComputerGraphicsLabs.Services.Services.Implenetation.Output
{
    public class PpmOutputService : IOutputService
    {
        public void DrawPicture(Picture picture)
        {
            var path = "C:\\Users\\Lenovo\\Desktop\\file.ppm";
            var  file = new StreamWriter(path);
            file.WriteLine("P3");

            var pixels = picture.Pixels;
            var rows = picture.Pixels.GetLength(0);
            var colums = picture.Pixels.GetLength(1);

            file.WriteLine(rows + " " + colums);
            file.WriteLine("255");
            file.WriteLine();
            
            for (int i = 0; i < pixels.Length; i++)
            {
                var x = i / colums;
                var y = i % colums;
                var pixel = pixels[x, y];

                var color = GetColor(pixel);

                file.WriteLine(color.R + " " + color.G + " " + color.B);
            }
            file.Flush();
            file.Close();
        }
        
        private Color GetColor(Pixel pixel)
        {
            if (!pixel.HasIntersection) return Color.White;
            if (pixel.HasIntersection && pixel.AngleBeetwinLightAndViewRay <= 0) return Color.Black;
            if (pixel.AngleBeetwinLightAndViewRay >= 0 && pixel.HasShadow) return Color.DarkGray;

            var colorR = (int)(250 * pixel.AngleBeetwinLightAndViewRay);
            if (colorR > 250) colorR = 250;
            if (colorR < 1) colorR = 1;

            var color = Color.FromArgb(0, colorR, 0, 0);

            return color;
        }
    }
}
