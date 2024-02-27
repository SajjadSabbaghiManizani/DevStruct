using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IGenericService<TEntity, TDto> where TEntity : class
        where TDto : class
    {
        Task<TEntity> InsertAsync(TDto entity);
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
    }
    public interface IGenericService<TEntity> where TEntity : class
    {
        Task<TEntity> InsertAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
    }
    public interface IGenericService<TEntity, RequestDTO,ResponseDTo> where TEntity : class
    {
        Task<TEntity> InsertAsync(RequestDTO entity);
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task UpdateAsync(RequestDTO entity);
        Task DeleteAsync(int id);
    }
}


