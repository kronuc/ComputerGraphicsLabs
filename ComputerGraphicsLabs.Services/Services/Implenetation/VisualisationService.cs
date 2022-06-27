using ComputerGraphicsLabs.Models.ComputeObjects;
using ComputerGraphicsLabs.Models.MainObjects;
using ComputerGraphicsLabs.Models.VisibleObjects;
using ComputerGraphicsLabs.Services.Abstracion;
using System.Collections.Generic;

namespace ComputerGraphicsLabs.Services.Services.Implenetation
{
    public class VisualisationService : IVisualisationService
    {
        private Scene _scene;

        public VisualisationService()
        {
            Initialise();
        }

        public void AddVisibleObjects(List<VisibleObject> visibleObject)
        {
            _scene.VisibleObject.AddRange(visibleObject);
        }


        public Picture GetPicture()
        {
            return _scene.GetPicture();
        }

        private void Initialise()
        {
            var viewer = new Viewer(
                height: 5,
                width: 5,
                pixelInHeight: 400,
                pixelinWidth: 400,
                new Coordinates(15, 0, 0),
                new Vector(new Coordinates(-1, 0, 0)),
                5
                );

            var light = new Light(new Point(new Coordinates(600, -100, 300)));
            _scene = new Scene(viewer, light);
        }

    }
}
