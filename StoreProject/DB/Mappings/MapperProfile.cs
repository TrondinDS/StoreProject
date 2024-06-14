using StoreProject.DB.DTO.ProductType;
using StoreProject.DB.DTO.User;
using StoreProject.DB.ModelDTO.Product;
using StoreProject.DB.Models;
using StoreProject.DB.ModelDTO.Order;
using StoreProject.DB.ModelDTO.OrderItem;
using AutoMapper;

namespace StoreProject.DB.Mappings
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // Маппинг для User
            CreateMap<User, UserDTO>().ReverseMap();

            //Маппинг для Order
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderItem, OrderItemDTO>()
                .ForMember(x => x.Count, x => x.MapFrom(l => l.OrderInformation.CountProduct))
                .ForMember(x => x.Price, x => x.MapFrom(l => l.OrderInformation.Price));

            // Маппинг для Product
            CreateMap<Product, ProductDTO>().ReverseMap();

            // Маппинг для ProductType
            CreateMap<ProductType, ProductTypeDTO>().ReverseMap();
        }
    }
}
