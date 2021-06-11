using AutoMapper;
using MS_User.Application.Dto;
using MS_User.Domain.Entities;
using System.Linq;

namespace MS_User.Application.Mapper
{
    public class AutoMapperObject : Profile
    {
        public AutoMapperObject()
        {
            CreateMap<TransferDTO, Account>()
                .ForMember(a => a.Id, b => b.MapFrom(c => c.AccountId))
                .ForMember(a => a.AccountAmount, b => b.MapFrom(c => c.Amount))
                .ReverseMap();

            CreateMap<AccountTransactionDTO, AccountTransaction>()
                .ReverseMap();

            CreateMap<PositionDTO, Account>()
                .ReverseMap();

            CreateMap<StockDTO, Stock>()
               .ReverseMap()
             .ForMember(a => a.AccountId, b => b.Ignore());

        }
    }
}