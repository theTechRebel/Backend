using Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Backend.Core.Data
{
    public interface IEntityRepository<T> 
        where T : //keyword used  when imposing a constraint on the generic parameter T
        class, //It must be a class (reference type) meaning T can't be an int, float, double, DateTime or any other struct (value type)
        IEntity, //The type argument must be or implement the specified IEntity. Multiple interface constraints can be specified. The constraining interface can also be generic.
        new() //must have a public parameter-less default constructor. Must be specified last

        //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters
    {
        T Get(Expression<Func<T, bool>> filter);

        List<T> GetList(Expression<Func<T, bool>> filter = null);

        T Add(T entity);

        T Update(T entity);

        bool Delete(T entity);
    }
}
