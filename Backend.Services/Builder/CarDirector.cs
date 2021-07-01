using Backend.Services.Decorator.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Services.Builder
{
    public class CarDirector
    {
        public void ConstructBlackToyotaHatch(ICarBuilder builder) {
            builder.setColor("BLACK").setMake("Toyotal Hatch").setYear("2021");
        }
    }
}
