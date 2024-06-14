using StoreProject.DB.DTO.ProductType;
using StoreProject.DB.DTO.User;
using StoreProject.DB.ModelDTO.Product;
using StoreProject.DB.Models;
using AutoMapper;
using StoreProject.DB.ModelDTO.Order;
using StoreProject.DB.ModelDTO.OrderItem;

namespace StoreProject.DB.Mappings
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // Маппинг для User
            CreateMap<User, UserDTO>().ReverseMap();

            // Маппинг для Order
            //CreateMap<Order, OrderDTO>().ReverseMap();
            //CreateMap<OrderItem, OrderItemDTO>()
            //    .ForMember(x => x.Count, x => x.MapFrom(l => l.OrderProductInformation.))
            //    .ForMember(x => x.Price, x => x.MapFrom(l => l.OrderProductInformation.));

            // Маппинг для Product
            CreateMap<Product, ProductDTO>().ReverseMap();

            // Маппинг для ProductType
            CreateMap<ProductType, ProductTypeDTO>().ReverseMap();
        }
    }
}
