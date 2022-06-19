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
            xCoordinate %= PixelInWidth;
            yCoordinate %= PixelInHeight;
            var height = (-(PixelInHeight / 2) + xCoordinate) * (Height / PixelInHeight) + (Height / (2 * PixelInHeight));
            var width = (-(PixelInWidth / 2) + yCoordinate) * (Width / PixelInWidth) + (Width / (2 * PixelInWidth));
            var hMult = height / _direcionOfTop.GetModule();
            var up = new Vector(new Coordinates(_direcionOfTop.Coordinates.XCoorinate * hMult,
                _direcionOfTop.Coordinates.YCoorinate * hMult,
                _direcionOfTop.Coordinates.ZCoorinate * hMult));

            
            var down1 = new Vector(new Coordinates(0,
                -_direcionOfTop.Coordinates.ZCoorinate,
                -_direcionOfTop.Coordinates.YCoorinate));

            var wMult = width / down1.GetModule();
            var down = new Vector(new Coordinates(0,
                -_direcionOfTop.Coordinates.ZCoorinate * wMult,
                -_direcionOfTop.Coordinates.YCoorinate * wMult));

            var resutlV = new Vector(new Coordinates(up.Coordinates.XCoorinate + down.Coordinates.XCoorinate,
                up.Coordinates.YCoorinate + down.Coordinates.YCoorinate,
                up.Coordinates.ZCoorinate + down.Coordinates.ZCoorinate));

            var dwMult = DistanseToViewMatrix / ViewDirection.GetModule();
            var newDW = new Vector(new Coordinates(ViewDirection.Coordinates.XCoorinate * dwMult,
                ViewDirection.Coordinates.YCoorinate * dwMult,
                ViewDirection.Coordinates.ZCoorinate * dwMult));

            var centerOfMatrix = new Coordinates(newDW.Coordinates.XCoorinate + Coordinates.XCoorinate,
                newDW.Coordinates.YCoorinate + Coordinates.YCoorinate,
                newDW.Coordinates.ZCoorinate + Coordinates.ZCoorinate);

            var pointOmMatrix = new Coordinates(resutlV.Coordinates.XCoorinate + centerOfMatrix.XCoorinate,
                resutlV.Coordinates.YCoorinate + centerOfMatrix.YCoorinate,
                resutlV.Coordinates.ZCoorinate + centerOfMatrix.ZCoorinate);

            var resultRayDirection = CreateVectorByTwoPoints(Coordinates, pointOmMatrix);

            var resutl = new Ray(centerOfMatrix, resultRayDirection);
            return resutl;
        }

        private void CountDirecionOfTop()
        {
            if(ViewDirection.Coordinates.YCoorinate == 0 && ViewDirection.Coordinates.ZCoorinate == 0)
            {
                _direcionOfTop = new Vector(new Coordinates(0, 0, 1));
                return;
            }

            var x = (Math.Pow(ViewDirection.Coordinates.YCoorinate, 2) 
                + Math.Pow(ViewDirection.Coordinates.ZCoorinate, 2)) 
                / ViewDirection.Coordinates.XCoorinate;
            var y = -ViewDirection.Coordinates.YCoorinate;
            var z = -ViewDirection.Coordinates.ZCoorinate;
            _direcionOfTop = new Vector(new Coordinates(x, y, z));
        }

        private Vector CreateVectorByTwoPoints(Coordinates start, Coordinates end)
        {
            var x = end.XCoorinate - start.XCoorinate;
            var y = end.YCoorinate - start.YCoorinate;
            var z = end.ZCoorinate - start.ZCoorinate;
            return new Vector(new Coordinates(x, y, z));
        }
    }
}
