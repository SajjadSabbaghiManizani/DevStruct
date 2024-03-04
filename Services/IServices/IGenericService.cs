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
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<bool> Exists(Guid id);
    }
}