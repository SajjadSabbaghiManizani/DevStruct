using Application.DTOs;
using Application.Services;
using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IProductService : IGenericCRUDService<ProductDetails, ProductDetailsRequestDto>
    {
       
    }
}
