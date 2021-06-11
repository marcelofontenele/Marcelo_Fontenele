using AutoMapper;
using Microsoft.Extensions.Configuration;
using MS_User.Application.Dto;
using MS_User.Application.Interfaces;
using MS_User.Domain.Entities;
using MS_User.Domain.Interfaces.Services;
using System;

namespace MS_User.Application.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly IMapper mapper;
        private readonly IAccountService accountService;
        private readonly IConfiguration configuration;

        public AppUserService(
            IMapper _mapper,
            IConfiguration _configuration,
            IAccountService _accountService)
        {
            this.mapper = _mapper ?? throw new NullReferenceException(nameof(IMapper)); ;
            this.configuration = _configuration ?? throw new NullReferenceException(nameof(IConfiguration));
            this.accountService = _accountService ?? throw new NullReferenceException(nameof(IAccountService));
        }

        public PositionDTO GetPosition(int userId)
        {
            return this.mapper.Map<PositionDTO>(this.accountService.GetByUserId(userId));
        }
    }
}