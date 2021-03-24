using System.Collections.Generic;
using System.Threading.Tasks;
using JWTAuthentication.DAL.Interfaces;
using JWTAuthentication.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JWTAuthentication.DAL.EFCore
{
    public abstract class Repository<TEntity, TContext> : IRepository<TEntity>
        where TEntity: class, IEntity
        where TContext: DbContext
    {
        private readonly TContext _context;
        protected readonly DbSet<TEntity> _entities;

        protected Repository(TContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            var entity = await _entities.FindAsync(id);
            _entities.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Get(int id)
        {
            return await _entities.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
