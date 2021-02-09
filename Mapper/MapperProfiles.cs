using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apshop.Data.DTOs;
using apshop.Data.Models;
using AutoMapper;

namespace apshop.Mapper
{
    public class MapperProfiles:Profile
    {
        public MapperProfiles()
        {

            CreateMap<User, UserDto>().ReverseMap();
         
            CreateMap<UserDto, User>().ReverseMap();

            CreateMap<Cart, CartDto>().ReverseMap();

            //CreateMap<Order, OrderDto>().ReverseMap();

            //CreateMap<CartItem, OrderItemDto>().ReverseMap();

            //CreateMap<OrderItem, OrderItemDto>().ReverseMap();

            CreateMap<Item, ItemDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
            
            // CreateMap<ItemDetails, ItemDetailsDto>().ReverseMap();
        }
    }
}
