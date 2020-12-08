using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSU_ThreeLayer.Entities;
using SSU_ThreeLayer.ViewModel;
using AutoMapper;

namespace SSU_ThreeLayer.App_Start
{
    public class AutoMapperWebConfig
    {
        public static MapperConfiguration Config { get; private set; }

        public static void RegisterMaps()
        {
            Config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, VisUserVM>();
                cfg.CreateMap<User, UserVM>();
                cfg.CreateMap<UserVM, User>()
                    .ForMember(dest => dest.IdUser, src => src.Ignore())
                    .ForMember(dest => dest.NameUser, src => src.Ignore())
                    .ForMember(dest => dest.DateOfBirth, src => src.Ignore())
                    .ForMember(dest => dest.ShopList, src => src.Ignore())
                    .ForMember(dest => dest.Ratings, src => src.Ignore());

                cfg.CreateMap<Shop, VisShopVM>();
                cfg.CreateMap<Shop, ShopVM>();
                cfg.CreateMap<ShopVM, Shop>()
                    .ForMember(dest => dest.IdShop, src => src.Ignore())
                    .ForMember(dest => dest.typeOfShop, src => src.Ignore())
                    .ForMember(dest => dest.address, src => src.Ignore())
                    .ForMember(dest => dest.UserList, src => src.Ignore())
                    .ForMember(dest => dest.Ratings, src => src.Ignore());

                cfg.CreateMap<Rating, VisRatingVM>();
                cfg.CreateMap<Rating, RatingVM>();
                cfg.CreateMap<RatingVM, Rating>()
                    .ForMember(dest => dest.User, src => src.Ignore())
                    .ForMember(dest => dest.Shop, src => src.Ignore());

                cfg.CreateMap<Address, AddressVM>();
                cfg.CreateMap<AddressVM, Address>()
                .ForMember("Country", opt => opt.MapFrom(src => src.Country))
                .ForMember("City", opt => opt.MapFrom(src => src.City))
                .ForMember("Street", opt => opt.MapFrom(src => src.Street))
                .ForMember("Build", opt => opt.MapFrom(src => src.Build));

                cfg.CreateMap<TypeOfShop, TypeOfShopVM>();
                cfg.CreateMap<TypeOfShopVM, TypeOfShop>()
                .ForMember("Description", opt => opt.MapFrom(src => src.Description));
            });
            Config.AssertConfigurationIsValid();
        }
    }
}