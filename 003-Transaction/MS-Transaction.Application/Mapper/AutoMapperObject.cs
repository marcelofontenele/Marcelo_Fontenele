using AutoMapper;
using MS_Transaction.Application.Dto;
using MS_Transaction.Domain.Entities;

namespace MS_Transaction.Application.Mapper
{
    public class AutoMapperObject : Profile
    {
        public AutoMapperObject()
        {
            CreateMap<TransferDTO, Transfer>();

            CreateMap<OriginDTO, Origin>();

            CreateMap<TargetDTO, Target>();
        }
    }
}