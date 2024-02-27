using System;
using System.Collections.Generic;
using System.Linq;
using Application.Excepions;
using AutoMapper;
using System.Linq.Expressions;
using Application.Interfaces.Repository;
using Services.IServices;
using Domain.Entities;
using Application.DTOs;


namespace Services.Services
{

    public class GenericService<TEntity, TDto> : IGenericService<TEntity, TDto>
     where TEntity : class
     where TDto : class
    {
        private readonly IGenericRepository<TEntity> _repository;
        private readonly IMapper _mapper;
        public IGenericUnitOfWork _unitOfWork;

        public GenericService(IGenericRepository<TEntity> repository, IMapper mapper , IGenericUnitOfWork genericUnitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TEntity> InsertAsync(TDto dto)
        {
            var entity =_mapper.Map<TEntity>(dto);
            await _repository.InsertAsync(entity); 
            await _unitOfWork.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> GetByIdAsync(int id)
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

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

    }

}

