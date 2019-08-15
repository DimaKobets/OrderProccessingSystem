using AutoMapper;
using OrderProcessingSystem.Contracts.Http;
using OrderProcessinSystem.Models;

namespace OrderProcessinSystem.Map
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDto, Order>()
                .ForMember(x => x.Oxid, m => m.MapFrom(x => x.OxId))
                .ForMember(x => x.OrderDate, m => m.MapFrom(x => x.OrderDatetime))
                .ForMember(x => x.BillingAddress, m => m.MapFrom(x => x.BillingAddresses))
                .ForMember(x => x.Payments, m => m.MapFrom(x => x.Payments))
                .ForMember(x => x.Articles, m => m.MapFrom(x => x.Articles));

            CreateMap<BillingAddressDto, BillingAddress>()
                .ForMember(x => x.CounryInfo, m => m.MapFrom(x => new CountryInfo { GeoCode = x.Country }))
                .ForMember(x => x.ZipCode, m => m.MapFrom(x => x.Zip));

            CreateMap<PaymentDto, Paymant>();

            CreateMap<ArticleDto, Article>();

            CreateMap<Order, OrderDto>()
                .ForMember(x => x.OxId, m => m.MapFrom(x => x.Oxid))
                .ForMember(x => x.OrderDatetime, m => m.MapFrom(x => x.OrderDate))
                .ForMember(x => x.BillingAddresses, m => m.MapFrom(x => x.BillingAddress))
                .ForMember(x => x.Payments, m => m.MapFrom(x => x.Payments))
                .ForMember(x => x.Articles, m => m.MapFrom(x => x.Articles));

            CreateMap<BillingAddress, BillingAddressDto>()
                .ForMember(x => x.Country, m => m.MapFrom(x => x.CounryInfo.GeoCode))
                .ForMember(x => x.Zip, m => m.MapFrom(x => x.ZipCode));

            CreateMap<Paymant, PaymentDto>();

            CreateMap<Article, ArticleDto>();
        }
    }
}
