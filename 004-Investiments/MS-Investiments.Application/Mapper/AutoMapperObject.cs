using AutoMapper;
using MS_Investiments.Application.Dto;
using MS_Investiments.Domain.Entities;

namespace MS_Investiments.Application.Mapper
{
    public class AutoMapperObject : Profile
    {
        public AutoMapperObject()
        {
            CreateMap<AccountTransactionDTO, AccountTransaction>()
                .ReverseMap();

            CreateMap<StockDTO, Stock>()
                .ReverseMap();

            CreateMap<OrderDTO, Order>()
                .ReverseMap();
        }
    }
}