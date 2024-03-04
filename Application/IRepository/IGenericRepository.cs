using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repository
{
    public interface IGenericRepository<TEntity> :IDisposable where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Guid id);
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entityToUpdate);
        Task DeleteAsync(TEntity entity);
        
    }
}
