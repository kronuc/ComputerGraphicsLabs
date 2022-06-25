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
            var expectedX = -point.Coordinates.XCoorinate;
            var expectedY = -point.Coordinates.YCoorinate;
            var expectedZ = -point.Coordinates.ZCoorinate;

            // act
            var result = -point;

            // assert
            result.Coordinates.XCoorinate.Should().Be(expectedX);
            result.Coordinates.YCoorinate.Should().Be(expectedY);
            result.Coordinates.ZCoorinate.Should().Be(expectedZ);
        }

        [Fact]
        public void PointSum_TwoPoints_NewPointCoordinatesEquilToExpected()
        {
            // arrange
            var pointA = AutoFaker.Generate<Point>();
            var pointB = AutoFaker.Generate<Point>();
            var expectedX = pointA.Coordinates.XCoorinate + pointB.Coordinates.XCoorinate;
            var expectedY = pointA.Coordinates.YCoorinate + pointB.Coordinates.YCoorinate;
            var expectedZ = pointA.Coordinates.ZCoorinate + pointB.Coordinates.ZCoorinate;

            // act
            var result = pointA + pointB;

            // assert
            result.Coordinates.XCoorinate.Should().Be(expectedX);
            result.Coordinates.YCoorinate.Should().Be(expectedY);
            result.Coordinates.ZCoorinate.Should().Be(expectedZ);
        }


        [Fact]
        public void PointDif_TwoPoints_NewPointCoordinatesEquilToExpected()
        {
            // arrange
            var pointA = AutoFaker.Generate<Point>();
            var pointB = AutoFaker.Generate<Point>();
            var expectedX = pointA.Coordinates.XCoorinate - pointB.Coordinates.XCoorinate;
            var expectedY = pointA.Coordinates.YCoorinate - pointB.Coordinates.YCoorinate;
            var expectedZ = pointA.Coordinates.ZCoorinate - pointB.Coordinates.ZCoorinate;

            // act
            var result = pointA - pointB;

            // assert
            result.Coordinates.XCoorinate.Should().Be(expectedX);
            result.Coordinates.YCoorinate.Should().Be(expectedY);
            result.Coordinates.ZCoorinate.Should().Be(expectedZ);
        }
    }
}
