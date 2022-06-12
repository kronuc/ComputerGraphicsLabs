using ComputerGraphicsLabs.Models.ComputeObjects;
using ComputerGraphicsLabs.Models.MainObjects;
using ComputerGraphicsLabs.Models.VisibleObjects;
using ComputerGraphicsLabs.Services.Abstracion;
using ComputerGraphicsLabs.Visualisation;
using System;

namespace ComputerGraphicsLabs.Services.Services.Implenetation
{
    public class VisualisationService : IVisualisationService
    {
        private Picture _picture;
        private IPainter _painter;

        public VisualisationService(IPainter painter)
        {
            _painter = painter;
            Initialise();
        }

        public void AddVisibleObjects(VisibleObject visibleObject)
        {
        }

        public void Visualise()
        {
            var pixels = new Pixel[20, 80];
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 80; j++)
                pixels[i, j] = new Pixel((Collors)(j%3));
            }
            _painter.Paint(pixels);
        }

        private void Initialise()
        {
            var viewer = new Viewer(
                height: 100,
                width: 100,
                pixelInHeight: 20,
                pixelinWidth: 20,
                new Coordinates(0,0,0),
                new Vector(new Coordinates(0, 0, 0)),
                200
                );

            var light = new Light(new Coordinates(0, 0, 0));

            _picture = new Picture(viewer, light);

        }
    }
}
