using ComputerGraphicsLabs.Models.ComputeObjects;
using System;

namespace ComputerGraphicsLabs.Models.MainObjects
{
    public class Viewer
    {
        private Vector _direcionOfTop;

        public int DistanseToViewMatrix { get; private set; }
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
            Vector viewDirection, 
            int distanseToViewMatrix)
        {
            Height = height;
            Width = width;
            PixelInHeight = pixelInHeight;
            PixelInWidth = pixelinWidth;
            Coordinates = coordinates;
            ViewDirection = viewDirection;
            DistanseToViewMatrix = distanseToViewMatrix;
            CountDirecionOfTop();
        }

        public Ray GetRayForPixel(int xCoordinate, int yCoordinate) 
        {
            xCoordinate %= PixelInHeight;
            yCoordinate %= PixelInWidth;
            var height = ((PixelInHeight / 2) - xCoordinate) * (Height / PixelInHeight) - (Height / (2 * PixelInHeight));
            var hMult = height / _direcionOfTop.GetModule();
            var up = _direcionOfTop * hMult;
            
            var sideDireciton = new Vector(new Coordinates(0,
                -_direcionOfTop.Coordinates.ZCoordinate,
                -_direcionOfTop.Coordinates.YCoordinate));
            var width = ((PixelInWidth / 2) - yCoordinate) * (Width / PixelInWidth) - (Width / (2 * PixelInWidth));
            var wMult = width / sideDireciton.GetModule();
            var side = new Vector(new Coordinates(0,
                -_direcionOfTop.Coordinates.ZCoordinate * wMult,
                -_direcionOfTop.Coordinates.YCoordinate * wMult));

            var resutlV = up + side;

            var dwMult = DistanseToViewMatrix / ViewDirection.GetModule();
            var newDW = ViewDirection * dwMult;

            var centerOfMatrix = new Coordinates(newDW.Coordinates.XCoordinate + Coordinates.XCoordinate,
                newDW.Coordinates.YCoordinate + Coordinates.YCoordinate,
                newDW.Coordinates.ZCoordinate + Coordinates.ZCoordinate);

            var pointOmMatrix = new Point(new Coordinates(resutlV.Coordinates.XCoordinate + centerOfMatrix.XCoordinate,
                resutlV.Coordinates.YCoordinate + centerOfMatrix.YCoordinate,
                resutlV.Coordinates.ZCoordinate + centerOfMatrix.ZCoordinate));
            

            var resultRayDirection = Vector.CreateVectorByTwoPoints(new Point(Coordinates), pointOmMatrix);

            var resutl = new Ray(new Point(centerOfMatrix), resultRayDirection);
            return resutl;
        }

        private void CountDirecionOfTop()
        {
            if(ViewDirection.Coordinates.YCoordinate == 0 && ViewDirection.Coordinates.ZCoordinate == 0)
            {
                _direcionOfTop = new Vector(new Coordinates(0, 0, 1));
                return;
            }

            if(ViewDirection.Coordinates.XCoordinate == 0)
            {
                _direcionOfTop = new Vector(new Coordinates(1, 0, 0));
                return;
            }

            var x = (Math.Pow(ViewDirection.Coordinates.YCoordinate, 2) 
                + Math.Pow(ViewDirection.Coordinates.ZCoordinate, 2)) 
                / ViewDirection.Coordinates.XCoordinate;
            var y = -ViewDirection.Coordinates.YCoordinate;
            var z = -ViewDirection.Coordinates.ZCoordinate;
            _direcionOfTop = - new Vector(new Coordinates(x, y, z));
        }
    }
}
