using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Services.State
{
    public class InitialColorState : IColorState
    {
        public string _color { get; set; }
        public InitialColorState(string color)
        {
            _color = color;
        }
        public IColorState handleColorChange(string input)
        {
            if(input == "")
            {
                return new BlackColorState("black");
            }
            else
            {
                return new WhiteColorState("white");
            }
        }
    }
}
