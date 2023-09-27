using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Services.Builder
{
    public class StringCarBuilder : ICarBuilder
    {
        private Car _car = new Car();

        public ICarBuilder setColor(string color)
        {
            this._car.color = color;
            return this;
        }

        public ICarBuilder setMake(string make)
        {
            this._car.make = make;
            return this;
        }

        public ICarBuilder setYear(string year)
        {
            this._car.year = year;
            return this;
        }

        public string Build()
        {
            return $"{this._car.color} {this._car.make} {this._car.year}";
        }
    }
}
