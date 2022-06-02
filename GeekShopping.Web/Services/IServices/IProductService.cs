using GeekShopping.Web.Models;

namespace GeekShopping.Web.Services.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> FindAllProducts(string token);
        Task<ProductModel> FindById(long id, string token);
        Task<ProductModel> CreateProduct(ProductModel product, string token);
        Task<ProductModel> UpdateProduct(ProductModel product, string token);
        Task<ProductModel> DeleteProductById(long id, string token);
    }
}
