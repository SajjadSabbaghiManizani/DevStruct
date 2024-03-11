using Application.DTOs;
using Application.Interfaces.Repository;
using AutoMapper;
using Domain.Entities;
using Services.IServices;

namespace Services.Services
{
    public class ProductService : GenericService<ProductDetails, ProductDetailsRequestDto>, IProductService
    {
        public ProductService(IGenericRepository<ProductDetails> repository, IMapper mapper, IGenericUnitOfWork genericUnitOfWork) : base(repository, mapper, genericUnitOfWork)
        {
        }
    }
}
