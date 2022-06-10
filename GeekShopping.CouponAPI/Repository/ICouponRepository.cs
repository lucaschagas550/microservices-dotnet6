using GeekShopping.CouponAPI.Data.ValueObjects;

namespace GeekShopping.CouponAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponVo> GetCouponByCouponCode(string couponCode);
    }
}
