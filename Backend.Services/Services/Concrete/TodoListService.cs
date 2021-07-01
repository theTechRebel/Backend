using Backend.Services.Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Backend.Services.Services.Concrete
{
    public class TodoListService : ITodoListService
    {
        private readonly  Dictionary<int, string> _dictionary;
        public TodoListService()
        {
            _dictionary = new Dictionary<int, string>();
        }

        public int Add(string item)
        {
            int number = _dictionary.Count;
            number += 1;
            _dictionary.Add(number, item);
            return number;
        }

        public Dictionary<int, string> List()
        {
            return _dictionary;
        }

        public bool Remove(int itemId)
        {
           var result =  _dictionary.Remove(itemId);
            return result;
        }
    }
}
