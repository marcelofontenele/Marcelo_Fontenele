using AutoMapper;
using Microsoft.Extensions.Configuration;
using MS_Investiments.Application.Dto;
using MS_Investiments.Application.Interfaces;
using MS_Investiments.Domain.Entities;
using MS_Investiments.Domain.Interfaces.Services;
using System;

namespace MS_Investiments.Application.Services
{
    public class AppAccountService : IAppAccountService
    {
        private readonly IMapper mapper;
        private readonly IAccountService userService;
        private readonly IConfiguration configuration;

        public AppAccountService(
            IMapper _mapper,
            IConfiguration _configuration,
            IAccountService _userService)
        {
            this.mapper = _mapper ?? throw new NullReferenceException(nameof(IMapper)); ;
            this.configuration = _configuration ?? throw new NullReferenceException(nameof(IConfiguration));
            this.userService = _userService ?? throw new NullReferenceException(nameof(IAccountService));
        }

        public void ReceiveTransfer(AccountTransactionDTO _credit)
        {
            this.userService.ReceiveTransfer(this.mapper.Map<AccountTransaction>(_credit));
        }
    }
}