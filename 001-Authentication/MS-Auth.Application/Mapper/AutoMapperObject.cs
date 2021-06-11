using AutoMapper;
using MS_Auth.Application.Dto;
using MS_Auth.Domain.Entities;

namespace MS_Auth.Application.Mapper
{
    public class AutoMapperObject : Profile
    {
        public AutoMapperObject()
        {
            CreateMap<UserDTO, User>();
        }
    }
}