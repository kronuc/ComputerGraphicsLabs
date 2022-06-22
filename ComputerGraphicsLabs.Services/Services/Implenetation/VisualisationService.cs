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
                height: 100,
                width: 100,
                pixelInHeight: 200,
                pixelinWidth: 200,
                new Coordinates(0,0,0),
                new Vector(new Coordinates(1, 0, 0)),
                200
                );

            var light = new Light(new Coordinates(200, 1000, 100));
            _scene = new Scene(viewer, light);
        }

    }
}
