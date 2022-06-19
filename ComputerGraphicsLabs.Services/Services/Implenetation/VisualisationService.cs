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

        public event EventHandler me;

        public VisualisationService(IPainter painter)
        {
            _painter = painter;
            Initialise();
        }

        public void AddVisibleObjects(VisibleObject visibleObject)
        {
            _picture.VisibleObject.Add(visibleObject);
        }

        public void Visualise()
        {
            var pixels  = _picture.GetPicture();
            _painter.Paint(pixels);
        }

        private void Initialise()
        {
            var viewer = new Viewer(
                height: 100,
                width: 100,
                pixelInHeight: 200,
                pixelinWidth: 100,
                new Coordinates(0,0,0),
                new Vector(new Coordinates(1, 0, 0)),
                200
                );

            var light = new Light(new Coordinates(210, 200, 100));

            _picture = new Picture(viewer, light);
        }
    }
}
