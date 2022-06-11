﻿using ComputerGraphicsLabs.Models.ComputeObjects;

namespace ComputerGraphicsLabs.Models.MainObjects
{
    public class Viewer
    {
        public double Height { get; private set; }
        public double Width { get; private set; }
        public int PixelInHeight { get; private set; }
        public int PixelInWidth { get; private set; }
        public Coordinates Coordinates { get; private set; }
        public Vector ViewDirection { get; private set; } 

        public Viewer(double height,
            double width,
            int pixelInHeight,
            int pixelinWidth,
            Coordinates coordinates,
            Vector viewDirection)
        {
            Height = height;
            Width = width;
            PixelInHeight = pixelInHeight;
            PixelInWidth = pixelinWidth;
            Coordinates = coordinates;
            ViewDirection = viewDirection;
        }

        public Ray GetRayForPixel(int xCoordinate, int yCoordinate) 
        {
            return null;
        }
    }
}
