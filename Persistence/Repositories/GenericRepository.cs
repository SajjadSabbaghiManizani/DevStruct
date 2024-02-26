using Application.Interfaces.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EFCore.Repositories
{
    public  class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        private readonly DbContextClass _dbContext;
        private DbContext context;

        public GenericRepository(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task InsertAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entityToUpdate)
        {
            _dbContext.Set<TEntity>().Update(entityToUpdate);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entityToDelete = await _dbContext.Set<TEntity>().FindAsync(id);
            if (entityToDelete != null)
            {
                _dbContext.Set<TEntity>().Remove(entityToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose(); 
        }
    }
}

