using ComputerGraphicsLabs.Models.ComputeObjects;
using ComputerGraphicsLabs.Models.VisibleObjects;
using ComputerGraphicsLabs.Services.Services.Abstracion;
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
            var pattern = @"\s+";
            while (line != null)
            {
                ParseLineForNormals(Regex.Split(line, pattern));
                ParseLineForPoints(Regex.Split(line, pattern));
                ParseLineForVS(Regex.Split(line, pattern));
                line = streamReader.ReadLine();
            }
            
            return _visibleObjects;
        }

        public void ParseLineForPoints(string[] line)
        {
            if (line.Length == 0 || line[0] != "v")
                return;

            var x = float.Parse(line[1], CultureInfo.InvariantCulture);
            var y = float.Parse(line[2], CultureInfo.InvariantCulture);
            var z = float.Parse(line[3], CultureInfo.InvariantCulture);
            var coord = new Coordinates(x, y, z);
            var point = new Point(coord);
            _points.Add(point);

        }

        public void ParseLineForVS(string[] line)
        {
            if (line.Length == 0 || line[0] != "f")
                return;

            var firstSet = line[1].Split("/");
            var pointId = new List<int>();
            var normals = firstSet.Length > 2 ? new List<int>() : null;

            foreach (var indexes in line.Skip(1))
            {
                if (indexes == "") continue;
                var index = indexes.Split("/");
                pointId.Add(int.Parse(index[0]));
                normals?.Add(int.Parse(index[2]));
            }

            var objPoints = pointId.Select(index => _points[index - 1]).ToList();
            var objNormals = new List<Vector>();

            if (normals != null)
            {
                objNormals = normals.Select(index => _normals[index - 1]).ToList();
            }
            
            if (normals == null)
            {
                _visibleObjects.Add(new Tringle(objPoints[0], objPoints[1], objPoints[2]));
                return;
            }

            var normal = objNormals.FirstOrDefault();

            _visibleObjects.Add(new Tringle(objPoints[0], objPoints[1], objPoints[2],
                normal));
        }

        public void ParseLineForNormals(string[] line)
        {
            if (line.Length == 0 || line[0] != "vn")
                return;

            var x = float.Parse(line[1], CultureInfo.InvariantCulture);
            var y = float.Parse(line[2], CultureInfo.InvariantCulture);
            var z = float.Parse(line[3], CultureInfo.InvariantCulture);
            var coord = new Coordinates(x, y, z);
            var vector = new Vector(coord);
            _normals.Add(vector);
        }
    }
}
