using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Backend.Services.Prototype
{
    public class Shape
    {

        public AShape GetShape() 
        {
            var random = new Random();
            int randomNumber = random.Next(1, 20);

            CShape shape = null;
            if(randomNumber < 10)
                shape = new CShape(90, 3);
            if (randomNumber > 10)
                shape = new CShape(360, 4);

            return shape;
        } 
        
    }

    public interface IAShapeClone
    {
        public AShape Clone();
    }

    public abstract class AShape: IAShapeClone
    {
        public AShape(int degrees, int sides) {
            if (degrees == 90 && sides == 3)
                Name = "Isosceles";
            if (degrees == 360 && sides == 4)
                Name = "Square";
        }

        public string getName() => Name;
        public abstract AShape Clone();

        protected string Name { get; set; }
    }

    public class CShape : AShape
    {
        public CShape(int degrees, int sides) : base(degrees, sides)
        {
            this.degrees = degrees;
            this.sides = sides;
        }

        private int degrees;
        private int sides;

        public override AShape Clone()
        {
            var shape = new CShape(this.sides, this.degrees);
            shape.Name = this.Name;
            return shape;
        }
    }
}
