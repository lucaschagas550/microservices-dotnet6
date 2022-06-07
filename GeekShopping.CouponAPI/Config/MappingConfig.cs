using AutoMapper;

namespace GeekShopping.CouponAPI.Model.Context
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                //config.CreateMap<ProductVo, Product>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
