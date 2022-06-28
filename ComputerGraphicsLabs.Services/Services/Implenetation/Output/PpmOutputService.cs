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
            file.WriteLine(picture.Pixels.GetLength(0) + " " + picture.Pixels.GetLength(1));
            file.WriteLine("255");
            file.WriteLine();
            var pixels = picture.Pixels;
            var rows = pixels.GetUpperBound(0) + 1;
            var colums = pixels.Length / rows;

            for (int i = 0; i < pixels.Length; i++)
            {
                var x = i / colums;
                var y = i % colums;
                var pixel = pixels[x, y];

                var colorR = (int) (250 * pixel.AngleBeetwinLightAndViewRay);
                
                if (colorR > 250) colorR = 250;
                if (colorR < 1) colorR = 1;
                
                var color = Color.FromArgb(colorR, colorR, 0,0);
                
                if(pixel.HasIntersection && pixel.AngleBeetwinLightAndViewRay <= 0) color = Color.Black;
                if (pixel.AngleBeetwinLightAndViewRay >= 0 && pixel.HasShadow) color = Color.DarkGray;
                
                if (!pixel.HasIntersection) color = Color.White;

                file.WriteLine(color.R + " " + color.G + " " + color.B);
            }
            file.Flush();
            file.Close();
        }


        private void CheckPixelForAffiliationToRange(Pixel pixel, double from, double to, Color color, ref string result)
        {
            var isLargerThanFrom = pixel.AngleBeetwinLightAndViewRay >= from;
            var isSmallerThenTo = pixel.AngleBeetwinLightAndViewRay < to;
            if (isLargerThanFrom & isSmallerThenTo) result = color.R + " " + color.G + " " + color.B;
        }
    }
}
