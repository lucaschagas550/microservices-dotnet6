using GeekShopping.CartAPI.Data.ValueObjects;
using GeekShopping.CartAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.CartAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CartController : ControllerBase
    {
        private ICartRepository _repository;

        public CartController(ICartRepository repository)
        {
            _repository = repository ?? throw new
                ArgumentNullException(nameof(repository));
        }

        [HttpGet("find-cart/{id}")]
        public async Task<ActionResult<CartVo>> FindById(string id)
        {
            var cart = await _repository.FindCartByUserId(id);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        [HttpPost("add-cart")]
        public async Task<ActionResult<CartVo>> AddCart(CartVo vo)
        {
            var cart = await _repository.SaveOrUpdateCart(vo);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        [HttpPut("update-cart")]
        public async Task<ActionResult<CartVo>> UpdateCart(CartVo vo)
        {
            var cart = await _repository.SaveOrUpdateCart(vo);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        [HttpDelete("remove-cart/{id}")]
        public async Task<ActionResult<CartVo>> RemoveCart(int id)
        {
            var status = await _repository.RemoveFromCart(id);
            if (!status) return BadRequest();
            return Ok(status);
        }

        [HttpPost("apply-coupon")]
        public async Task<ActionResult<CartVo>> ApplyCoupon(CartVo vo)
        {
            var status = await _repository.ApplyCoupon(vo.CartHeader.UserId, vo.CartHeader.CouponCode);
            
            if (!status) return NotFound();

            return Ok(status);
        }

        [HttpDelete("remove-coupon/{userId}")]
        public async Task<ActionResult<CartVo>> RemoveCoupon(string userId)
        {
            var status = await _repository.RemoveCoupon(userId);

            if (!status) return NotFound();

            return Ok(status);
        }

        [HttpPost("checkout")]
        public async Task<ActionResult<CheckoutHeaderVo>> Checkout(CheckoutHeaderVo vo)
        {
            if (vo?.UserId == null) return BadRequest();
            var cart = await _repository.FindCartByUserId(vo.UserId);
            if (cart == null) return NotFound();
            vo.CartDetails = cart.CartDetails;
            vo.DateTime = DateTime.Now;

            // RabbitMQ logic comes here!!!
            //_rabbitMQMessageSender.SendMessage(vo, "checkoutqueue");

            return Ok(vo);
        }
    }
}
