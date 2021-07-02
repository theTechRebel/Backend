using Backend.Core.Data.Ef;
using Backend.Data.Ef;
using Backend.Data.Ef.Concrete;
using Backend.Data.Ef.Repository;
using Backend.Data.Ef.Repository.Interfaces;
using Backend.Services.Concrete;
using Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Backend.Tests
{
    public class UserServiceTests
    {
        private readonly EfDbContext _context;
        private readonly EfUserRepository _userRepository;
        private readonly UserService _userService;
        
        public UserServiceTests()
        {
            var dbContext = new DbContextOptionsBuilder<EfDbContext>().UseInMemoryDatabase("TestDB");
            _context = new EfDbContext(dbContext.Options);
            _context.Database.EnsureCreated();
            _userRepository = new EfUserRepository(_context);
            _userService = new UserService(_userRepository);

        }

        [Fact]
        public void Add_IfNothingSavedWhenNULLIsPassed()
        {
            //arrange

            //act
            var result = _userService.Add(null);

            //assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Add_IfSomethingSavedWhenValidObjectIsPassed()
        {
            //arrange
            var newUser = new User() { Password = "123", Remember = true, Username = "MrNobody1" };

            //act
            var result = _userService.Add(newUser);


            //assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void Add_IfDuplicateObjectIsPassed()
        {
            //arrange
            UserService userService = new(_userRepository);
            var newUser = new User() { Password = "123", Remember = true, Username = "MrNobody" };
            var newUser2 = new User() { Password = "123", Remember = true, Username = "MrNobody" };

            //act
            var result = userService.Add(newUser);
            var result2 = userService.Add(newUser2);


            //assert
            Assert.Equal(1, result);
            Assert.Equal(0, result2);

        }




    }
}
