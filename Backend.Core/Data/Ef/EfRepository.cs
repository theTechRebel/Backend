using Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Backend.Core.Data.Ef
{
    public class EfRepository<TEntity>
        : IEntityRepository<TEntity>
        where TEntity :
        class,
        IEntity,
        new()
    {
        private readonly DbContext _context;
        public EfRepository(DbContext context) { _context = context; }
        public TEntity Add(TEntity entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            _context.SaveChanges();
            return addedEntity.Entity;
        }

        public bool Delete(TEntity entity)
        {
            try
            {
                var addedEntity = _context.Entry(entity);
                    addedEntity.State = EntityState.Deleted;
                    _context.SaveChanges();
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            return true;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>().FirstOrDefault(filter);
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ? _context.Set<TEntity>().ToList() 
                    : _context.Set<TEntity>().Where(filter).ToList();
        }

        public TEntity Update(TEntity entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Modified;
            _context.SaveChanges();
            return addedEntity.Entity;
        }
    }
}
