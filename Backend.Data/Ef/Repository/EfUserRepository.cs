﻿using Backend.Core.Data.Ef;
using Backend.Data.Ef.Concrete;
using Backend.Data.Ef.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data.Ef.Repository
{
    public class EfUserRepository :
        EfRepository<User>,
        IUserRepository
    {
        public EfUserRepository(EfDbContext context) : base(context)
        {
        }
    }
}
