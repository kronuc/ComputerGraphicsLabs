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
            var xSquere = Math.Pow(vector.Coordinates.XCoordinate, 2);
            var ySquere = Math.Pow(vector.Coordinates.YCoordinate, 2);
            var zSquere = Math.Pow(vector.Coordinates.ZCoordinate, 2);
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
            var x = endPointCoord.XCoordinate - startPointCoord.XCoordinate;
            var y = endPointCoord.YCoordinate - startPointCoord.YCoordinate;
            var z = endPointCoord.ZCoordinate - startPointCoord.ZCoordinate;
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
            var x = vCoord.YCoordinate * uCoord.ZCoordinate - vCoord.ZCoordinate * uCoord.YCoordinate;
            var y = vCoord.ZCoordinate * uCoord.XCoordinate - vCoord.XCoordinate * uCoord.ZCoordinate;
            var z = vCoord.XCoordinate * uCoord.YCoordinate - vCoord.YCoordinate * uCoord.XCoordinate;

            // act
            var result = Vector.Cross(v, u);

            // assert
            Math.Abs(x - result.Coordinates.XCoordinate).Should().BeLessThan(ACCURACY);
            Math.Abs(y - result.Coordinates.YCoordinate).Should().BeLessThan(ACCURACY);
            Math.Abs(z - result.Coordinates.ZCoordinate).Should().BeLessThan(ACCURACY);
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
            expectedResult += vCoord.XCoordinate * uCoord.XCoordinate;
            expectedResult += vCoord.YCoordinate * uCoord.YCoordinate;
            expectedResult += vCoord.ZCoordinate * uCoord.ZCoordinate;

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
            var expectedX = -vector.Coordinates.XCoordinate;
            var expectedY = -vector.Coordinates.YCoordinate;
            var expectedZ = -vector.Coordinates.ZCoordinate;
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
            var expectedX = vector.Coordinates.XCoordinate * num;
            var expectedY = vector.Coordinates.YCoordinate * num;
            var expectedZ = vector.Coordinates.ZCoordinate * num;
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
            var expectedX = vector.Coordinates.XCoordinate / num;
            var expectedY = vector.Coordinates.YCoordinate / num;
            var expectedZ = vector.Coordinates.ZCoordinate / num;

            // act
            var result = vector / num;

            // assert
            Math.Abs(expectedX - result.Coordinates.XCoordinate).Should().BeLessThan(ACCURACY);
            Math.Abs(expectedY - result.Coordinates.YCoordinate).Should().BeLessThan(ACCURACY);
            Math.Abs(expectedZ - result.Coordinates.ZCoordinate).Should().BeLessThan(ACCURACY);
        }

        [Fact]
        public void VectorSum_TwoVectors_NewVectorCoordinatesEquilToExpected()
        {
            // arrange
            var vectorA = AutoFaker.Generate<Vector>();
            var vectorB = AutoFaker.Generate<Vector>();
            var expectedX = vectorA.Coordinates.XCoordinate + vectorB.Coordinates.XCoordinate;
            var expectedY = vectorA.Coordinates.YCoordinate + vectorB.Coordinates.YCoordinate;
            var expectedZ = vectorA.Coordinates.ZCoordinate + vectorB.Coordinates.ZCoordinate;
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
            var expectedX = vector.Coordinates.XCoordinate + point.Coordinates.XCoordinate;
            var expectedY = vector.Coordinates.YCoordinate + point.Coordinates.YCoordinate;
            var expectedZ = vector.Coordinates.ZCoordinate + point.Coordinates.ZCoordinate;
            var expectedResultCoordinates = new Coordinates(expectedX, expectedY, expectedZ);
            var expectedResult = new Vector(expectedResultCoordinates);

            // act
            var result = vector + point;

            // assert
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
