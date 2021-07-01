using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Services.State
{
    public class ColorContext
    {
        private IColorState _colorState;

        public ColorContext()
        {
            _colorState = new InitialColorState("none");
        }

        public IColorState getColorState()
        {
            return _colorState;
        }

        public IColorState handleColorChange(string color)
        {
            var newState = _colorState.handleColorChange(color);
            _colorState = newState;
            return newState;
        }
    }
}
