using ComputerGraphicsLabs.Models.ComputeObjects;
using ComputerGraphicsLabs.Models.MainObjects;
using ComputerGraphicsLabs.Models.MainObjects.InfoObjects;
using System;

namespace ComputerGraphicsLabs.Models.VisibleObjects
{
    public class Sphere : VisibleObject
    {
        public Coordinates Center { get; private set; }
        public double Radius { get; private set; }

        public Sphere(Coordinates center, double radius)
        {
            Center = center;
            Radius = radius;
        }

        public override IntersecitonInfo Getintersection(Ray ray)
        {
            throw new System.NotImplementedException();
        }
    }

    
}
