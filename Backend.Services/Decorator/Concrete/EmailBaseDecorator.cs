using Backend.Services.Decorator.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Services.Decorator.Concrete
{
    public abstract class EmailBaseDecorator : IEmailDecorator
    {
        public IEmailDecorator AddedState { set; get; }
        public string GetDecoratedBody()
        {
            return string.Concat(this.GetBody(), Environment.NewLine, AddedState.GetBody());
        }
        public abstract string GetBody();
    }
}
