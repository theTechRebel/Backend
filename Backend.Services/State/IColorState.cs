using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Services.State
{
    public interface IColorState
    {
        string _color { get; set; }       
        public IColorState handleColorChange(string color);
    }
}
