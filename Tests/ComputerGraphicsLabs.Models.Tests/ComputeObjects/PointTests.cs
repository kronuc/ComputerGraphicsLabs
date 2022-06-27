using AutoBogus;
using ComputerGraphicsLabs.Models.ComputeObjects;
using FluentAssertions;
using Xunit;

namespace ComputerGraphicsLabs.Models.Tests
{
    public class PointTests
    {
        [Fact]
        public void PointNegative_Point_NewPointCoordinatesEquilToExpected()
        {
            // arrange
            var point = AutoFaker.Generate<Point>();
            var expectedX = -point.Coordinates.XCoordinate;
            var expectedY = -point.Coordinates.YCoordinate;
            var expectedZ = -point.Coordinates.ZCoordinate;

            // act
            var result = -point;

            // assert
            result.Coordinates.XCoordinate.Should().Be(expectedX);
            result.Coordinates.YCoordinate.Should().Be(expectedY);
            result.Coordinates.ZCoordinate.Should().Be(expectedZ);
        }

        [Fact]
        public void PointSum_TwoPoints_NewPointCoordinatesEquilToExpected()
        {
            // arrange
            var pointA = AutoFaker.Generate<Point>();
            var pointB = AutoFaker.Generate<Point>();
            var expectedX = pointA.Coordinates.XCoordinate + pointB.Coordinates.XCoordinate;
            var expectedY = pointA.Coordinates.YCoordinate + pointB.Coordinates.YCoordinate;
            var expectedZ = pointA.Coordinates.ZCoordinate + pointB.Coordinates.ZCoordinate;

            // act
            var result = pointA + pointB;

            // assert
            result.Coordinates.XCoordinate.Should().Be(expectedX);
            result.Coordinates.YCoordinate.Should().Be(expectedY);
            result.Coordinates.ZCoordinate.Should().Be(expectedZ);
        }


        [Fact]
        public void PointDif_TwoPoints_NewPointCoordinatesEquilToExpected()
        {
            // arrange
            var pointA = AutoFaker.Generate<Point>();
            var pointB = AutoFaker.Generate<Point>();
            var expectedX = pointA.Coordinates.XCoordinate - pointB.Coordinates.XCoordinate;
            var expectedY = pointA.Coordinates.YCoordinate - pointB.Coordinates.YCoordinate;
            var expectedZ = pointA.Coordinates.ZCoordinate - pointB.Coordinates.ZCoordinate;

            // act
            var result = pointA - pointB;

            // assert
            result.Coordinates.XCoordinate.Should().Be(expectedX);
            result.Coordinates.YCoordinate.Should().Be(expectedY);
            result.Coordinates.ZCoordinate.Should().Be(expectedZ);
        }
    }
}
