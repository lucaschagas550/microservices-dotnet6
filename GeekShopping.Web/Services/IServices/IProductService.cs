using GeekShopping.Web.Models;

namespace GeekShopping.Web.Services.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> FindAllProduct();
        Task<ProductModel> FindById(long id);
        Task<ProductModel> CreateProduct(ProductModel product);
        Task<ProductModel> UpdateProduct(ProductModel product);
        Task<ProductModel> DeleteProductById(long id);
    }
}
