using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Services.Factory
{
    //Factory Pattern
    //Factory method applies when you have a single factory outputing different kind of objects
    //We have 3 types of formats
    //Number, Data, String
    //what decides what kind of object gets created is the FormatFactory
    //this is done through the static Create method
    //happens at compile time
    public class FormatFactory
    {
        public static IFormat Create(string data)
        {
           if( int.TryParse(data, out var output))
            {
                return new NumberFormat() { Number = output };
            }

           if( DateTime.TryParse(data, out var output1))
            {
                return new DateFormat() { Date = output1 };
            }

            return new StringFormat() { Content = data };
        }
    }

    public interface IFormat
    {
        string Content { get; set; }

        //Prototype Pattern
        //object must be able to clone itself
        IFormat Clone();
    }

    public class NumberFormat : IFormat
    {
        public string Content { get; set; }
        public int Number { get; set; }

        //The clone or copy method creates a new identical object i.e use prototype to create a new object
        public IFormat Clone()
        {
            return new NumberFormat() { Number = this.Number };
        }
    }

    public class DateFormat : IFormat
    {
        public string Content { get; set; }
        public DateTime Date { get; set; }

        //The clone or copy method creates a new identical object i.e use prototype to create a new object
        public IFormat Clone()
        {
            return new DateFormat() { Date = this.Date };
        }
    }

    public class StringFormat : IFormat
    {
        public string Content { get; set; }

        //The clone or copy method creates a new identical object i.e use prototype to create a new object
        public IFormat Clone()
        {
            return new StringFormat() { Content = this.Content };
        }
    }


    //Abstract Factory Pattern
    //abstract factory applies when you want to have multiple factories outputing multiple objects
    //dependeny inversion - higher order objects are not depending on lower order objects 
    //all of them are dpending on abstractions
    //abstract method create does the magic
    //happens at compile time
    public interface IFormatFactory
    {
        public abstract IFormat Create(string data);
    }

    public class NumberFormatFactory : IFormatFactory
    {
        public IFormat Create(string data)
        {
            if(int.TryParse(data,out var num))
            {
                return new NumberFormat { Content = data, Number = num};
            }
            throw new Exception();
        }
    }

    public class DateFormatFactory : IFormatFactory
    {
        public IFormat Create(string data)
        {
            if (DateTime.TryParse(data, out var date))
            {
                return new DateFormat { Content = data, Date = date };
            }
            throw new Exception();
        }
    }
}
