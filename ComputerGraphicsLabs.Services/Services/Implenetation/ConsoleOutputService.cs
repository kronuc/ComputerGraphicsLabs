using ComputerGraphicsLabs.Models.MainObjects;
using ComputerGraphicsLabs.Services.Services.Abstracion;
using System;

namespace ComputerGraphicsLabs.Services.Services.Implenetation
{
    public class ConsoleOutputService : IOutputService
    {
        public void DrawPicture(Picture picture)
        {
            var pixel = picture.GetPicture();
            var result = "";
            var rows = pixel.GetUpperBound(0) + 1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < pixel.Length / rows; j++)
                {
                    result += "*";
                }
                result += "\n";
            }
            Console.WriteLine(result);
        }
    }
}
