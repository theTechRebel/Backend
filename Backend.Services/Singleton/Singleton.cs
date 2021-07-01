using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Services.Singleton
{
    public class Singleton
    {
        private Singleton _instance;
        internal Singleton()
        {
            _instance = new Singleton();
        }

        public Singleton getInstance()
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
