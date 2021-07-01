using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Services.State
{
    public class ResolveColorState : IColorState
    {
        public string _color { get; set; }
        public ResolveColorState(string color)
        {
            _color = color;
        }
        public IColorState handleColorChange(string input)
        {
            return this;
        }
    }
}
