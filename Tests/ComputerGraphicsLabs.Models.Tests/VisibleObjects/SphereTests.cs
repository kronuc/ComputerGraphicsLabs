using ComputerGraphicsLabs.Models.ComputeObjects;
using ComputerGraphicsLabs.Models.VisibleObjects;
using FluentAssertions;
using System;
using Xunit;

namespace ComputerGraphicsLabs.Models.Tests.VisibleObjects
{
    public class SphereTests
    {
        [Fact]
        public void GetIntersecition_MissengRay_NoIntersection()
        {
            // arange
            var point = new Point(new Coordinates(1, 0, 0));
            var sphere = new Sphere(point, 0.5f);

            var rayOrigin = new Point(new Coordinates(0, 0, 0));
            var rayDirection = new Vector(new Coordinates(0, 0, 1));
            var ray = new Ray(rayOrigin, rayDirection);

            // act
            var result = sphere.Getintersection(ray);

            // assert
            result.HasIntersecion.Should().BeFalse();
        }


        [Fact]
        public void GetIntersecition_Ray_Intersection()
        {
            // arange
            var point = new Point(new Coordinates(1, 0, 0));
            var sphere = new Sphere(point, 0.5f);

            var rayOrigin = new Point(new Coordinates(0, 0, 0));
            var rayDirection = new Vector(new Coordinates(1, 0, 0));
            var ray = new Ray(rayOrigin, rayDirection);

            // act
            var result = sphere.Getintersection(ray);

            // assert
            result.HasIntersecion.Should().BeTrue();
            Math.Abs(result.DistanceToInterseciton - 0.5).Should().BeLessThan(0.000001);
        }
    }
}
