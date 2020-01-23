using Backend.Core.Data;
using Backend.Data.Ef.Concrete;

namespace Backend.Data.Ef.Repository.Interfaces
{
    public interface IUserRepository: IEntityRepository<User>
    {
    }
}
