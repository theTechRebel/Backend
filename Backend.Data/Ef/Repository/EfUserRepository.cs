using Backend.Core.Data.Ef;
using Backend.Data.Ef.Concrete;
using Backend.Data.Ef.Repository.Interfaces;

namespace Backend.Data.Ef.Repository
{
    public class EfUserRepository :
        EfRepository<User, EfDbContext>,
        IUserRepository
    {
    }
}
