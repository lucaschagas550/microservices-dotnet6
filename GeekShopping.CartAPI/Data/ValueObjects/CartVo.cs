namespace GeekShopping.CartAPI.Data.ValueObjects
{
    public class CartVo
    {
        public CartHeaderVo CartHeader { get; set; }
        public IEnumerable<CartDetailVo> CartDetails { get; set; }
    }
}
