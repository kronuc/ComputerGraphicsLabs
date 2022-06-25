using AutoBogus;
using ComputerGraphicsLabs.Models.ComputeObjects;
using FluentAssertions;
using System;
using Xunit;

namespace ComputerGraphicsLabs.Models.Tests.ComputeObjects
{
    public class VectorTests
    {
        private const double ACCURACY = 0.00001;

        [Fact]
        public void GetModult_Vector_ResultAndExpectedResultAreEquil()
        {
            // arrange
            var vector = AutoFaker.Generate<Vector>();
            var xSquere = Math.Pow(vector.Coordinates.XCoorinate, 2);
            var ySquere = Math.Pow(vector.Coordinates.YCoorinate, 2);
            var zSquere = Math.Pow(vector.Coordinates.ZCoorinate, 2);
            var expectedResult = Math.Pow(xSquere + ySquere + zSquere, 0.5);

            // act
            var result = vector.GetModule();

            // assert
            result.Should().Be(expectedResult);
        }

        [Fact]
        public void CreateVectorByTwoPoints_TwoPoints_ResultAndExpectedResultAreEquil()
        {
            // arrange
            var start = AutoFaker.Generate<Point>();
            var end = AutoFaker.Generate<Point>();
            var startPointCoord = start.Coordinates;
            var endPointCoord = end.Coordinates;
            var x = endPointCoord.XCoorinate - startPointCoord.XCoorinate;
            var y = endPointCoord.YCoorinate - startPointCoord.YCoorinate;
            var z = endPointCoord.ZCoorinate - startPointCoord.ZCoorinate;
            var expectedResultCoordinates = new Coordinates(x, y, z);
            var expectedResult = new Vector(expectedResultCoordinates);

            // act
            var result = Vector.CreateVectorByTwoPoints(start, end);

            // assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void Cross_TwoVectors_ResultAndExpectedResultAreEquil()
        {
            // arrange
            var v = AutoFaker.Generate<Vector>();
            var u = AutoFaker.Generate<Vector>();
            var vCoord = v.Coordinates;
            var uCoord = u.Coordinates;
            var x = vCoord.YCoorinate * uCoord.ZCoorinate - vCoord.ZCoorinate * uCoord.YCoorinate;
            var y = vCoord.ZCoorinate * uCoord.XCoorinate - vCoord.XCoorinate * uCoord.ZCoorinate;
            var z = vCoord.XCoorinate * uCoord.YCoorinate - vCoord.YCoorinate * uCoord.XCoorinate;

            // act
            var result = Vector.Cross(v, u);

            // assert
            Math.Abs(x - result.Coordinates.XCoorinate).Should().BeLessThan(ACCURACY);
            Math.Abs(y - result.Coordinates.YCoorinate).Should().BeLessThan(ACCURACY);
            Math.Abs(z - result.Coordinates.ZCoorinate).Should().BeLessThan(ACCURACY);
        }

        [Fact]
        public void Dot_Vector_ResultAndExpectedResultAreEquil()
        {
            // arrange
            var v = AutoFaker.Generate<Vector>();
            var u = AutoFaker.Generate<Vector>();
            var expectedResult = 0d;
            var vCoord = v.Coordinates;
            var uCoord = u.Coordinates;
            expectedResult += vCoord.XCoorinate * uCoord.XCoorinate;
            expectedResult += vCoord.YCoorinate * uCoord.YCoorinate;
            expectedResult += vCoord.ZCoorinate * uCoord.ZCoorinate;

            // act
            var result = Vector.Dot(v, u);

            // assert
            result.Should().Be(expectedResult);
        }

        [Fact]
        public void VectorNegative_Vector_NewVectorCoordinatesEquilToExpected()
        {
            // arrange
            var vector = AutoFaker.Generate<Vector>();
            var expectedX = -vector.Coordinates.XCoorinate;
            var expectedY = -vector.Coordinates.YCoorinate;
            var expectedZ = -vector.Coordinates.ZCoorinate;
            var expectedResultCoordinates = new Coordinates(expectedX, expectedY, expectedZ);
            var expectedResult = new Vector(expectedResultCoordinates);

            // act
            var result = -vector;

            // assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void VectorMultiplyOnDouble_VectorAndDouble_NewVectorCoordinatesEquilToExpected()
        {
            // arrange
            var vector = AutoFaker.Generate<Vector>();
            var num = AutoFaker.Generate<double>();
            var expectedX = vector.Coordinates.XCoorinate * num;
            var expectedY = vector.Coordinates.YCoorinate * num;
            var expectedZ = vector.Coordinates.ZCoorinate * num;
            var expectedResultCoordinates = new Coordinates(expectedX, expectedY, expectedZ);
            var expectedResult = new Vector(expectedResultCoordinates);

            // act
            var result = vector * num;

            // assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void VectorDivideOnDouble_VectorAndDouble_NewVectorCoordinatesEquilToExpected()
        {
            // arrange
            var vector = AutoFaker.Generate<Vector>();
            var num = AutoFaker.Generate<double>();
            var expectedX = vector.Coordinates.XCoorinate / num;
            var expectedY = vector.Coordinates.YCoorinate / num;
            var expectedZ = vector.Coordinates.ZCoorinate / num;

            // act
            var result = vector / num;

            // assert
            Math.Abs(expectedX - result.Coordinates.XCoorinate).Should().BeLessThan(ACCURACY);
            Math.Abs(expectedY - result.Coordinates.YCoorinate).Should().BeLessThan(ACCURACY);
            Math.Abs(expectedZ - result.Coordinates.ZCoorinate).Should().BeLessThan(ACCURACY);
        }

        [Fact]
        public void VectorSum_TwoVectors_NewVectorCoordinatesEquilToExpected()
        {
            // arrange
            var vectorA = AutoFaker.Generate<Vector>();
            var vectorB = AutoFaker.Generate<Vector>();
            var expectedX = vectorA.Coordinates.XCoorinate + vectorB.Coordinates.XCoorinate;
            var expectedY = vectorA.Coordinates.YCoorinate + vectorB.Coordinates.YCoorinate;
            var expectedZ = vectorA.Coordinates.ZCoorinate + vectorB.Coordinates.ZCoorinate;
            var expectedResultCoordinates = new Coordinates(expectedX, expectedY, expectedZ);
            var expectedResult = new Vector(expectedResultCoordinates);

            // act
            var result = vectorA + vectorB;

            // assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void VectorAddPoint_VectorAndPoint_NewVectorCoordinatesEquilToExpected()
        {
            // arrange
            var vector = AutoFaker.Generate<Vector>();
            var point = AutoFaker.Generate<Vector>();
            var expectedX = vector.Coordinates.XCoorinate + point.Coordinates.XCoorinate;
            var expectedY = vector.Coordinates.YCoorinate + point.Coordinates.YCoorinate;
            var expectedZ = vector.Coordinates.ZCoorinate + point.Coordinates.ZCoorinate;
            var expectedResultCoordinates = new Coordinates(expectedX, expectedY, expectedZ);
            var expectedResult = new Vector(expectedResultCoordinates);

            // act
            var result = vector + point;

            // assert
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
