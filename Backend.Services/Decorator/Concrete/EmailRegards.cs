using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Services.Decorator.Concrete
{
    public class EmailRegards: EmailBaseDecorator
    {
        private readonly string Signature;
        public EmailRegards(string signature)
        {
            this.Signature = signature;
        }

        public override string GetBody()
        {
            return $"Warm regards {Environment.NewLine} {this.Signature}";
        }
    }
}
