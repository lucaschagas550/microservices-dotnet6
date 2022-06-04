using System.Net.Http.Headers;
using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;

namespace GeekShopping.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        private const string BasePath = "api/product";

        public ProductService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<ProductViewModel>> FindAllProducts(string token)
        {
            //Add token no header da requisição
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<ProductViewModel>>();
        }

        public async Task<ProductViewModel> FindProductById(long id, string token)
        {
            //Add token no header da requisição
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ProductViewModel>();
        }

        public async Task<ProductViewModel> CreateProduct(ProductViewModel product, string token)
        {
            //Add token no header da requisição
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PostAsJson(BasePath, product);

            if (!response.IsSuccessStatusCode) throw new Exception("Something went wrong when calling API.");

            return await response.ReadContentAs<ProductViewModel>();
        }

        public async Task<ProductViewModel> UpdateProduct(ProductViewModel product, string token)
        {
            //Add token no header da requisição
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PutAsJson(BasePath, product);

            if (!response.IsSuccessStatusCode) throw new Exception("Something went wrong when calling API.");

            return await response.ReadContentAs<ProductViewModel>();
        }

        public async Task<ProductViewModel> DeleteProductById(long id, string token)
        {
            //Add token no header da requisição
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.DeleteAsync($"{BasePath}/{id}");

            if (!response.IsSuccessStatusCode) throw new Exception("Something went wrong when calling API.");

            return await response.ReadContentAs<ProductViewModel>();
        }
    }
}
