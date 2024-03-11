using Application.Interfaces.Repository;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Services.IServices;


namespace Services.Services
{

    public class GenericService<TEntity, TDto> : IGenericService<TEntity, TDto>
     where TEntity : BaseEntity
     where TDto : class
    {
        private readonly IGenericRepository<TEntity> _repository;
        private readonly IMapper _mapper;
        public IGenericUnitOfWork _unitOfWork;

        public GenericService(IGenericRepository<TEntity> repository, IMapper mapper, IGenericUnitOfWork genericUnitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = genericUnitOfWork;
        }
        public async Task<TEntity> InsertAsync(TDto dto)
        {
            if(dto != null)
            {
                var entity = _mapper.Map<TEntity>(dto);
                await _repository.InsertAsync(entity);
                await _unitOfWork.SaveChangesAsync();
                return entity;
            }
            else
            {
                return null;
            }
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            if (id == null)
            {
                return await _repository.GetByIdAsync(id);
            }
            else
            {
                return null;
            }
   
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _repository.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await _repository.Delete(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> Exists(Guid id)
        {

            var result = await _repository.GetByIdAsync(id);
            if (result == null)
                return false;
            return true;
        }

    }

}

