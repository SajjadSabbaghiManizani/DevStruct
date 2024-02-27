using Application.DTOs;
using Application.Interfaces.Repository;
using AutoMapper;
using Domain.Entities;
using Services.IServices;

namespace Services.Services
{
    public class ProductService : GenericService<ProductDetails, ProductDetailsRequestDto>, IProductService
    {
        public IGenericUnitOfWork _unitOfWork;
        private readonly IGenericService<ProductDetails, ProductDetailsRequestDto> _appService;
        private readonly IMapper _mapper;
       public ProductService(IGenericUnitOfWork unitOfWork, IGenericService<ProductDetails, ProductDetailsRequestDto> appService, IMapper mapper)
           : base(unitOfWork.GetRepository<ProductDetails>(), mapper)
       {
           _unitOfWork = unitOfWork;
           _appService = appService;
           _mapper = mapper;
       }

        //public async Task<bool> CreateProduct(ProductDetailsRequestDto productDetailsRequestDto)
        //{
        //    if (productDetailsRequestDto != null)
        //    {
        //        var entity = _mapper.Map<ProductDetails>(productDetailsRequestDto);
        //        await _unitOfWork.GetRepository<ProductDetails>().InsertAsync(entity);
        //        await _unitOfWork.SaveChangesAsync();
        //        return true;
        //    }
        //    return false;
        //}

        //public async Task<ProductDetails> GetByIdAsync(int id)
        //{
        //    if(id != null) 
        //    {
        //        var
        //    }
        //}
      
    }
}
