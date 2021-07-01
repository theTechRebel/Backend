using Backend.Data.Ef.Concrete;
using Backend.Data.Ef.Repository.Interfaces;
using Backend.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Backend.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        public int Add(User user)
        {
            if (user != null)
            {
                var result = _userRepo.Get(u => u.Username == user.Username);
                if(result == null)
                {
                    return _userRepo.Add(user).Id;

                }
            }
            return 0;
        }

        public bool Delete(int UserId)
        {
            var user = _userRepo.Get(u => u.Id == UserId);
            return user != null ? _userRepo.Delete(user) : false;
        }

        public User Get(string username, string password)
        {
            return _userRepo.Get(u => u.Username == username && u.Password == password);
        }

        public List<User> GetAll()
        {
            return _userRepo.GetList();
        }
    }
}
