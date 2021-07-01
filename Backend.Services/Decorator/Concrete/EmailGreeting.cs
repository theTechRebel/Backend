using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Services.Decorator.Concrete
{
    public class EmailGreeting : EmailBaseDecorator
    {
        private readonly string Recipient;
        public EmailGreeting(string recipient)
        {
            this.Recipient = recipient;
        }
        public override string GetBody()
        {
            return $"Greeting {Recipient}";
        }
    }
}
