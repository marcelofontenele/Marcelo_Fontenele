using AutoMapper;
using Microsoft.Extensions.Configuration;
using MS_User.Application.Dto;
using MS_User.Application.Interfaces;
using MS_User.Domain.Entities;
using MS_User.Domain.Interfaces.Services;
using System;

namespace MS_User.Application.Services
{
    public class AppAccountService : IAppAccountService
    {
        private readonly IMapper mapper;
        private readonly IAccountService accountService;
        private readonly IConfiguration configuration;

        public AppAccountService(
            IMapper _mapper,
            IConfiguration _configuration,
            IAccountService _accountService)
        {
            this.mapper = _mapper ?? throw new NullReferenceException(nameof(IMapper)); ;
            this.configuration = _configuration ?? throw new NullReferenceException(nameof(IConfiguration));
            this.accountService = _accountService ?? throw new NullReferenceException(nameof(IAccountService));
        }

        public void DebitOrderEmited(AccountTransactionDTO _debit)
        {
            this.accountService.DebitOrderEmited(this.mapper.Map<AccountTransaction>(_debit));

        }

        public void ReceiveTransfer(AccountTransactionDTO _credit)
        {
            this.accountService.ReceiveTransfer(this.mapper.Map<AccountTransaction>(_credit));
        }
    }
}