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

        public ProductService(IGenericUnitOfWork unitOfWork, IGenericService<ProductDetails,ProductDetailsRequestDto> appService,IMapper mapper)
        : base(appService)  
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _appService = appService ?? throw new ArgumentNullException();
            _mapper = mapper ?? throw new ArgumentNullException();
        }

       public async Task<bool> CreateProduct(ProductDetailsRequestDto productDetailsRequestDto)
       {
           if (productDetailsRequestDto != null)
           {
                var entity = _mapper.Map<ProductDetails>(productDetailsRequestDto);
                await _unitOfWork.GetRepository<ProductDetails>().InsertAsync(entity);








               await _unitOfWork.(productDetails);

               var result = _unitOfWork.Save();

               if (result > 0)
                   return true;
               else
                   return false;
           }
           return false;
       }







        //public async Task<bool> DeleteProduct(int productId)
        //{
        //    if (productId > 0)
        //    {
        //        var productDetails = await _unitOfWork.Products.GetById(productId);
        //        if (productDetails != null)
        //        {
        //            _unitOfWork.Products.Delete(productDetails);
        //            var result = _unitOfWork.Save();

        //            if (result > 0)
        //                return true;
        //            else
        //                return false;
        //        }
        //    }
        //    return false;
        //}

        //public async Task<IEnumerable<ProductDetails>> GetAllProducts()
        //{
        //    var productDetailsList = await _unitOfWork.Products.GetAll();
        //    return productDetailsList;
        //}

        //public async Task<ProductDetails> GetProductById(int productId)
        //{
        //    if (productId > 0)
        //    {
        //        var productDetails = await _unitOfWork.Products.GetById(productId);
        //        if (productDetails != null)
        //        {
        //            return productDetails;
        //        }
        //    }
        //    return null;
        //}

        //public async Task<bool> UpdateProduct(ProductDetails productDetails)
        //{
        //    if (productDetails != null)
        //    {
        //        var product = await _unitOfWork.Products.GetById(productDetails.Id);
        //        if(product != null)
        //        {
        //            product.ProductName= productDetails.ProductName;
        //            product.ProductDescription= productDetails.ProductDescription;
        //            product.ProductPrice= productDetails.ProductPrice;
        //            product.ProductStock= productDetails.ProductStock;

        //            _unitOfWork.Products.Update(product);

        //            var result = _unitOfWork.Save();

        //            if (result > 0)
        //                return true;
        //            else
        //                return false;
        //        }
        //    }
        //    return false;
        //}
    }
}
