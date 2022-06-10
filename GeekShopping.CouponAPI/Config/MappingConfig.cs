using AutoMapper;
using GeekShopping.CouponAPI.Data.ValueObjects;

namespace GeekShopping.CouponAPI.Model.Context
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponVo, Coupon>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
