using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Services.State
{
    public class WhiteColorState : IColorState
    {
        public string _color { get; set; }

        public WhiteColorState(string color)
        {
            _color = color;
        }

        public IColorState handleColorChange(string input)
        {
            if(input  == "white")
            {
                return new BlackColorState("none");
            }
            else
            {
                return new ResolveColorState("none");
            }
        }
    }
}
