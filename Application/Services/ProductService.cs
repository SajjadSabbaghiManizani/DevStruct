using Application.Interfaces.Repository;
using Application.Interfaces.Services;
using Domain.Entities;

namespace Application.Services
{
    public class ProductService : GenericService<ProductDetails>, IProductService
    {
        public IUnitOfWork _unitOfWork;
        private readonly ICrudService<ProductDetails> _appService;

        public ProductService(IUnitOfWork unitOfWork, ICrudService<ProductDetails> appService)
        : base(appService)  
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _appService = appService ?? throw new ArgumentNullException();
        }
          






        //public async Task<bool> CreateProduct(ProductDetails productDetails)
        //{
        //    if (productDetails != null)
        //    {
        //        await _unitOfWork.Products.Add(productDetails);

        //        var result = _unitOfWork.Save();

        //        if (result > 0)
        //            return true;
        //        else
        //            return false;
        //    }
        //    return false;
        //}

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
