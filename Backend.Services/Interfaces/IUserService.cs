using Backend.Data.Ef.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Services.Interfaces
{
    public interface IUserService
    {
        List<User> GetAll();
        User Get(string username, string password);
        bool Delete(int UserId);
        int Add(User user);
    }
}
