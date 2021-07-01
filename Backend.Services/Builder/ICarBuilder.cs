using Backend.Services.Decorator.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Services.Builder
{
    public interface ICarBuilder
    {
        public ICarBuilder setColor(string color);
        public ICarBuilder setMake(string make);
        public ICarBuilder setYear(string year);
    }
}
