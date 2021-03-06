using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Repository;
using GeekShopping.ProductAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new
                ArgumentNullException(nameof(productRepository));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
        {
            var products = await _productRepository.FindAll();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVO>> FindById(long id)
        {
            var product = await _productRepository.FindById(id);
            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductVO>> CreateProduct([FromBody] ProductVO productVo)
        {
            if (productVo == null) return NotFound();

            var product = await _productRepository.Create(productVo);

            return Ok(product);
        }

        [HttpPut]
        public async Task<ActionResult<ProductVO>> UpdateProduct([FromBody] ProductVO productVo)
        {
            if (productVo == null) return NotFound();

            var product = await _productRepository.Update(productVo);

            return Ok(product);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<ProductVO>> DeleteProduct(long id)
        {
            var product = await _productRepository.Delete(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
    }
}
