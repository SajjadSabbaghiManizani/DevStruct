using Application.DTOs;
using Domain.Entities;

namespace Services.IServices
{
    public interface IProductService : IGenericService<ProductDetails, ProductDetailsRequestDto>
    {
       
    }
}
