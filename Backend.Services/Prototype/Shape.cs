using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Services.Prototype
{
    public class Shape
    {
        public void GetShape()
        {
            var shape = new Triangle();
            shape.Name = "Isosceles";
            var shape2 = shape.Clone();
        }
    }

    public interface IShape
    {
        int hasSides();
        int Degrees();
        public string Name { get; set; }
        public IShape Clone();
    }

    public class Triangle : IShape
    {
        private string _Name;
        public string Name { get => _Name; set => _Name = Name; }

        public int Degrees() => 90;

        public int hasSides() => 3;
        public IShape Clone()
        {
            var shape = new Triangle();
            shape.Name = _Name;
            return shape;
        }
    }
}
