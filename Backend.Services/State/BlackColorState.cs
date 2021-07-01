using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Services.State
{
    public class BlackColorState : IColorState
    {
        public string _color { get; set; }

        public BlackColorState(string color)
        {
            _color = color;
        }

        public IColorState handleColorChange(string input)
        {
            if(input == "black")
            {
                return new WhiteColorState("white");
            }
            else
            {
                return new ResolveColorState("none");
            }
        }
    }
}
