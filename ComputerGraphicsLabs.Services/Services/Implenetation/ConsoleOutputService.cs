using ComputerGraphicsLabs.Models.InfoObjects.MainObjects;
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
            var colums = pixels.Length / rows;

            for (int i = 0; i < pixels.Length; i++)
            {
                var x = i / colums;
                var y = i % colums;
                var pixel = pixels[x, y];

                if (y == 0 & x > 0) result += "\n";

                string addToResult = String.Empty;

                CheckPixelForAffiliationToRange(pixel, 0.8, double.PositiveInfinity, "#", ref addToResult);
                CheckPixelForAffiliationToRange(pixel, 0.5, 0.8, "O", ref addToResult);
                CheckPixelForAffiliationToRange(pixel, 0.2, 0.5, "*", ref addToResult);
                CheckPixelForAffiliationToRange(pixel, 0, 0.2, ".", ref addToResult);

                if (!pixel.HasIntersection || pixel.AngleBeetwinLightAndViewRay <= 0) addToResult = " ";

                result += addToResult;
            }
        
            Console.WriteLine(result);
        }

        private void CheckPixelForAffiliationToRange(Pixel pixel, double from, double to, string stringToAdd, ref string result)
        {
            var isLargerThanFrom = pixel.AngleBeetwinLightAndViewRay >= from;
            var isSmallerThenTo = pixel.AngleBeetwinLightAndViewRay < to;
            if (isLargerThanFrom & isSmallerThenTo) result = stringToAdd;
        }
    }
}
