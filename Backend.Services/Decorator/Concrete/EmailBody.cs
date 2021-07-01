using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Services.Decorator.Concrete
{
    public class EmailBody : EmailBaseDecorator
    {
        private readonly string Msg;
        public EmailBody(string msg)
        {
            this.Msg = msg;
        }
        public override string GetBody()
        {
            return $"Attention to the following message: {Environment.NewLine} {this.Msg}";
        }
    }
}
