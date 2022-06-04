using AutoMapper;
using GeekShopping.CartAPI.Data.ValueObjects;
using GeekShopping.CartAPI.Model;

namespace GeekShopping.CartAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVo, Product>().ReverseMap();
                config.CreateMap<CartHeaderVo, CartHeader>().ReverseMap();
                config.CreateMap<CartDetailVo, CartDetailVo>().ReverseMap();
                config.CreateMap<CartVo, Cart>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
