using Application.Interfaces.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Services.IServices;


namespace Services.Services
{

    public class GenericService<TEntity, TDto> : IGenericService<TEntity, TDto>
     where TEntity : class
     where TDto : class
    {
        private readonly IGenericRepository<TEntity> _repository;
        private readonly IMapper _mapper;
        public IGenericUnitOfWork _unitOfWork;

        public GenericService(IGenericRepository<TEntity> repository, IMapper mapper, IGenericUnitOfWork genericUnitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TEntity> InsertAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _repository.InsertAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
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
            await _repository.DeleteAsync(entity);
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

