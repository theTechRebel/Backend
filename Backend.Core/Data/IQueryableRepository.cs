using Backend.Core.Entities;
using System.Linq;

namespace Backend.Core.Data
{
    public interface IQueryableRepository<T> 
        where T: 
        class, 
        IEntity, 
        new()
    {
        IQueryable<T> Table { get; }
    }
}
