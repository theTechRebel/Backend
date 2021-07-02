using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Services.Delegate
{
    public class Delegate
    {
        string input;
        public Delegate()
        {
            input = "input";
            this.DoSomething(ToJson);
            this.DoSomething(ToXML);
            this.DoSomething(ToFormData);
        }


        public delegate string ReturnData();

        public string ToJson()
        {
            return input + "/";
        }
        public string ToXML()
        {
            return input + "<>";
        }
        public string ToFormData()
        {
            return input + ":" + input;
        }

        public void DoSomething(ReturnData data)
        {
            Console.WriteLine(data);
        }
    }
}
