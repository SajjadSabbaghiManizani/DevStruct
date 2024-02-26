using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IGenericCRUDService<TEntity,TEntityDto>
        where TEntityDto : class
    {
        Task<IEnumerable<TEntityDto>> GetAll(Expression<Func<TEntity, bool>>? where = null, params string[] includes);
        Task<TEntityDto?> GetById(Expression<Func<TEntity, bool>> predicateToGetId, params string[] includes);
        Task<TEntityDto> Add(TEntityDto dto, params Expression<Func<TEntity, object>>[] references);
        Task<TEntityDto> Update(TEntityDto dto, Expression<Func<TEntity, bool>>? where = null, params Expression<Func<TEntity, object>>[] references);
        Task<bool> Delete(int id);
    }
}


