using System;
using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Services;
using Application.Excepions;
using AutoMapper;
using System.Linq.Expressions;
using Application.Interfaces.Repository;


namespace Application.Services
{
    public class GenericCRUDService<TModel, TDto> : IGenericCRUDService<TModel, TDto>
      where TModel : class
      where TDto : class
    {
        private readonly IMapper _mapper;
  

        public GenericCRUDService(IMapper mapper)
        {
            _mapper = mapper;


        }

        public async Task<IEnumerable<TDto>> GetAll(Expression<Func<TModel, bool>>? where = null,
        params string[] includes)
        {
            var query = ApplyIncludes(_unitOfWork.Set<TModel>(), includes);

            if (where != null)
            {
                query = query.Where(where);
            }

            var entities = await query.ToListAsync();
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }
        // Rest of the methods will be implemented here
    }

}