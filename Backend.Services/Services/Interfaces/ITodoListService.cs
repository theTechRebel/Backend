using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Services.Services.Interfaces
{
    public interface ITodoListService
    {
        public Dictionary<int, string> List();
        public int Add(string item);
        public bool Remove(int itemId);
    }
}
