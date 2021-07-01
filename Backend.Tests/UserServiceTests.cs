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
        public UserServiceTests()
        {
            var dbContext = new DbContextOptionsBuilder<EfDbContext>().UseInMemoryDatabase("TestDB");
            _context = new EfDbContext(dbContext.Options);
            
        }

        public class UnitTest1: IClassFixture<UserServiceTests>
        {
            private readonly UserServiceTests _fixture;
            private readonly EfUserRepository _userRepository;

            public UnitTest1(UserServiceTests fixture)
            {
                _fixture = fixture;
                _fixture._context.Database.EnsureDeleted();
                _fixture._context.Database.EnsureCreated();
                _userRepository = new EfUserRepository(_fixture._context);
            }


            [Fact]
            public void Add_IfNothingSavedWhenNULLIsPassed()
            {
                //arrange
                UserService userService = new(_userRepository);

                //act
                var result = userService.Add(null);


                //assert
                Assert.Equal(0, result);
            }

            [Fact]
            public void Add_IfSomethingSavedWhenValidObjectIsPassed()
            {
                //arrange
                UserService userService = new(_userRepository);
                var newUser = new User() { Password = "123", Remember = true, Username = "MrNobody1" };

                //act
                var result = userService.Add(newUser);


                //assert
                Assert.Equal(2, result);
            }

        }


        public class UnitTest2 : IClassFixture<UserServiceTests>
        {
            private readonly UserServiceTests _fixture;
            private readonly EfUserRepository _userRepository;

            public UnitTest2(UserServiceTests fixture)
            {
                _fixture = fixture;
                _fixture._context.Database.EnsureDeleted();
                _fixture._context.Database.EnsureCreated();
                _userRepository = new EfUserRepository(_fixture._context);
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
}
