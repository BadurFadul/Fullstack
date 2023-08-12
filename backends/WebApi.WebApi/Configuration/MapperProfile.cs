using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.Business.Src.Dtos;
using WebApi.Domain.Src.Entities;

namespace WebApi.WebApi.Configuration
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<CartItem,CartItemReadDto>();
            CreateMap<CartItemUpdateDto, CartItem>();
            CreateMap<CartItemCreateDto, CartItem>();

            CreateMap<Category,CategoryReadDto>();
            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<CategoryCreateDto, Category>();

            CreateMap<OrderDetail,OrderDetailReadDto>();
            CreateMap<OrderDetailUpdateDto, OrderDetail>();
            CreateMap<OrderDetailCreateDto, OrderDetail>();

            CreateMap<Order,OrderReadDto>();
            CreateMap<OrderUpdateDto, Order>();
            CreateMap<OrderCreateDto, Order>();

            CreateMap<Payment,PaymentReadDto>();
            CreateMap<PaymentUpdateDto, Payment>();
            CreateMap<PaymentCreateDto, Payment>();

            CreateMap<Product,ProductReadDto>();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<ProductCreateDto, Product>();

            CreateMap<Review,ReviewReadDto>();
            CreateMap<ReviewUpdateDto, Review>();
            CreateMap<ReviewCreateDto, Review>();

            CreateMap<Shipping,ShippingReadDto>();
            CreateMap<ShippingUpdateDto, Shipping>();
            CreateMap<ShippingCreateDto, Shipping>();

            CreateMap<ShoppingCart,ShoppingCartReadDto>();
            CreateMap<ShoppingCartUpdateDto, ShoppingCart>();
            CreateMap<ShoppingCartCreateDto, ShoppingCart>();

            CreateMap<User,UserReadDto>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<UserCreateDto, User>();
        }
    }
}