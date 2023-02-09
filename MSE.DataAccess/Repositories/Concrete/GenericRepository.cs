using Microsoft.EntityFrameworkCore;
using MSE.DataAccess.Context;
using MSE.DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MSE.DataAccess.Repositories.Concrete
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<TEntity>> AddRange(List<TEntity> entity)
        {
            await _dbContext.AddRangeAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> Delete(TEntity entity)
        {
            _ = _dbContext.Remove(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<TEntity> Get(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return await (filter == null ? _dbContext.Set<TEntity>().ToListAsync() : _dbContext.Set<TEntity>().Where(filter).ToListAsync());
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _ = _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<TEntity>> UpdateRange(List<TEntity> entity)
        {
            _dbContext.UpdateRange(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
