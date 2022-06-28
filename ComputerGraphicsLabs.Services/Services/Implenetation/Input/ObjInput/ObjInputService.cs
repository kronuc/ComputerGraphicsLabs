using ComputerGraphicsLabs.Models.ComputeObjects;
using ComputerGraphicsLabs.Models.VisibleObjects;
using ComputerGraphicsLabs.Services.Services.Abstracion;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ComputerGraphicsLabs.Services.Services.Implenetation.Input.ObjInput
{
    public class ObjInputService : IInputService
    {
        private readonly List<Point> _points = new List<Point>();
        private readonly List<Vector> _normals = new List<Vector>();
        private readonly List<VisibleObject> _visibleObjects = new List<VisibleObject>();

        public List<VisibleObject> GetVisibleObjects()
        {
            using var streamReader = new StreamReader($"C:\\Users\\Lenovo\\Desktop\\cow.obj");

            var line = streamReader.ReadLine();

            while (line != null)
            {
                ParseLineForNormals(Regex.Split(line, @"\s+"));
                ParseLineForPoints(Regex.Split(line, @"\s+"));
                ParseLineForVS(Regex.Split(line, @"\s+"));
                line = streamReader.ReadLine();
            }
            
            return _visibleObjects;
        }

        public void ParseLineForPoints(string[] line)
        {
            if (line.Length == 0 || line[0] != "v")
                return;

            _points.Add(new Point(new Coordinates(
                float.Parse(line[1], CultureInfo.InvariantCulture),
                float.Parse(line[2], CultureInfo.InvariantCulture),
                float.Parse(line[3], CultureInfo.InvariantCulture))));
        }
        public void ParseLineForVS(string[] line)
        {
            if (line.Length == 0 || line[0] != "f")
                return;

            var firstIndex = line[1].Split("/");
            var vertices = new List<int>();
            var normals = firstIndex.Length > 2 ? new List<int>() : null;

            foreach (var indexes in line.Skip(1))
            {
                if (indexes == "") continue;
                var index = indexes.Split("/");
                vertices.Add(int.Parse(index[0]));
                normals?.Add(int.Parse(index[2]));
            }


            var faceVertices = vertices.Select(index => _points[index - 1]).ToList();
            var faceNormals = (IEnumerable<Vector>?)null;

            if (normals != null)
            {
                faceNormals = normals.Select(index => _normals[index - 1]).ToList();
            }
            
            var listVertices = vertices.ToList();

            if (listVertices.Count != 3)
                throw new NotImplementedException();

            if (normals is null)
            {
                _visibleObjects.Add(new Tringle(faceVertices[0], faceVertices[1], faceVertices[2]));
                return;
            }
            var listNormals = faceNormals.ToList();

            _visibleObjects.Add(new Tringle(faceVertices[0], faceVertices[1], faceVertices[2],
                listNormals[0], listNormals[1], listNormals[2]));
        }

        public void ParseLineForNormals(string[] line)
        {
            if (line.Length == 0 || line[0] != "vn")
                return;

            _normals.Add(new Vector(new Coordinates(
                float.Parse(line[1], CultureInfo.InvariantCulture),
                float.Parse(line[2], CultureInfo.InvariantCulture),
                float.Parse(line[3], CultureInfo.InvariantCulture))));
        }
    }
}
