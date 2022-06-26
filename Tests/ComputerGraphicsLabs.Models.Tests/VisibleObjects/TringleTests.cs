using ComputerGraphicsLabs.Models.ComputeObjects;
using ComputerGraphicsLabs.Models.VisibleObjects;
using FluentAssertions;
using Xunit;

namespace ComputerGraphicsLabs.Models.Tests.VisibleObjects
{
    public class TringleTests
    {
        
        [Fact]
        public void GetIntersecition_MissengRay_NoIntersection()
        {
            // arange
            var pointA = new Point(new Coordinates(1, 1, 1));
            var pointB = new Point(new Coordinates(1, 1, 0));
            var pointC = new Point(new Coordinates(1, 0, 1));
            var tringle = new Tringle(pointA, pointB, pointC);

            var rayOrigin = new Point(new Coordinates(0, 0, 0));
            var rayDirection = new Vector(new Coordinates(0, 0, 1));
            var ray = new Ray(rayOrigin, rayDirection);

            // act
            var result = tringle.Getintersection(ray);

            // assert
            result.HasIntersecion.Should().BeFalse();
        }


        [Fact]
        public void GetIntersecition_Ray_Intersection()
        {
            // arange
            var pointA = new Point(new Coordinates(1, 1, 1));
            var pointB = new Point(new Coordinates(1, -1, -1));
            var pointC = new Point(new Coordinates(1, 1, -1));
            var tringle = new Tringle(pointA, pointB, pointC);

            var rayOrigin = new Point(new Coordinates(0, 0, 0));
            var rayDirection = new Vector(new Coordinates(1, 0, 0));
            var ray = new Ray(rayOrigin, rayDirection);

            // act
            var result = tringle.Getintersection(ray);

            // assert
            result.HasIntersecion.Should().BeTrue();
            result.DistanceToInterseciton.Should().Be(1);
        }
    }
}
