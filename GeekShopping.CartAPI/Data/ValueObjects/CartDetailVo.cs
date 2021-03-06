using System.Security.AccessControl;

namespace GeekShopping.CartAPI.Data.ValueObjects
{
    public class CartDetailVo
    {
        public long Id { get; set; }
        public long CartHeaderId { get; set; }
        public long ProductId { get; set; }
        public int Count { get; set; }

        public CartHeaderVo CartHeader { get; set; }
        public ProductVo Product { get; set; }
    }
}
