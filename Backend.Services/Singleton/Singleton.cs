using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Services.Singleton
{
    //Singleton uses staic variable instance and static method getInstance()
    //instance is private
    //constructor is private stops from creating new instances using the new() keyword
    //getInstance() checks if instance is created and returns it if it is or createsa new one
    public class Singleton
    {
        private static Singleton _instance;
        private Singleton()
        {
        }

        public static Singleton getInstance()
        {
            if(_instance != null)
            {
                return _instance;
            }
            else
            {
                _instance = new Singleton();
                return _instance;
            }
        }
    }
}
